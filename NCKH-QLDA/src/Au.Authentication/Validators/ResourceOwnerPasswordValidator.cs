using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NCKH.Infrastruture.Binding.Helpers;
using NCKH.Infrastruture.Binding.Constans;
using Core.Domain.Models;
using Core.Domain.IServices;
using Core.Domain.IRepository;
using System.Numerics;

namespace Au.Authentication.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUserAccountRepository _userAccountRepository;
       // private readonly ITenantRepository _tenantRepository;
        //private readonly ILogger<ResourceOwnerPasswordValidator> _logger;
        private readonly IMemoryCache _cache;

        public ResourceOwnerPasswordValidator(
            IUserAccountService userAccountService,
            IUserAccountRepository userAccountRepository,
          //  ITenantRepository tenantRepository,
           // ILogger<ResourceOwnerPasswordValidator> logger,
            IMemoryCache cache
            )
        {
            _userAccountService = userAccountService;
            _userAccountRepository = userAccountRepository;
            //_tenantRepository = tenantRepository;
            //_logger = logger;
           _cache = cache;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //domain tham so đầu vào
           var userName = context.Request.Raw.Get("userName");
            if (string.IsNullOrEmpty(userName))
            {
                //  _logger.LogError("Domain_does_not_exists {0}", domain);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "domain_does_not_exists");
                return Task.CompletedTask;
            }

            string cacheKey = $"UserName:{userName}";
            var idAccount = string.Empty;
            bool isExist = _cache.TryGetValue(cacheKey, out idAccount);
            if (!isExist)
            {
                //trar ve domain đúng
                idAccount = Task.Run(() => _userAccountRepository.GetidKhoaByDomainAsync(userName)).Result;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromDays(1));
                _cache.Set(cacheKey, idAccount, cacheEntryOptions);
            }

            if (string.IsNullOrEmpty(idAccount))
            {
                // _logger.LogError("tenant_does_not_exists {0}", idKhoa);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Tài khoản không tồn tại.");
                return Task.CompletedTask;
            }

            var password = context.Request.Raw.Get("password");
            if (string.IsNullOrEmpty(password))
            {
                // _logger.LogError("type_does_not_exists {0}", type);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Password không để trống.");
                return Task.CompletedTask;
            }
            // thông tin user
            var userInfo = Task.Run(() => _userAccountRepository.GetInfoByUserNameAsync(idAccount,context.UserName)).Result;
            if (userInfo == null)
            {
                // _logger.LogError("account_does_not_exists");
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Tài khoản không tồn tại.");
                return Task.CompletedTask;
            }


            int totalFailCount;

            if (userInfo.LockoutEnabled && userInfo.LockoutEnd.HasValue && DateTime.Compare(userInfo.LockoutEnd.Value.DateTime, DateTime.Now) < 0 && userInfo.AccessFailedCount >= 5)
            {
                Task.Run(() => _userAccountService.ResetLockoutAsync(userInfo.IdBoMon, userInfo.LastUpdateUserId, userInfo.LastUpdateFullName, string.Empty, userInfo.UserName, userInfo.Type));
            }

            if (userInfo.LockoutEnabled && userInfo.LockoutEnd.HasValue)
            {
                if (DateTime.Compare(userInfo.LockoutEnd.Value.DateTime, DateTime.Now) < 0)
                {
                    // Reset access fail count.
                    Task.Run(() => _userAccountService.ResetLockoutAsync(userInfo.IdBoMon, userInfo.LastUpdateUserId, userInfo.LastUpdateFullName, string.Empty, userInfo.UserName, userInfo.Type));

                    // Validate password.
                    var validateResult = ValidatePassword(userInfo, context.UserName, context.Password, out totalFailCount);
                    if (!validateResult)
                    {
                       // _logger.LogError("invalid_username_or_password {0} {1}", userInfo.IdKhoa, userInfo.UserName);
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid_username_or_password", new Dictionary<string, object>
                        {
                            {"failCount", totalFailCount }
                        });
                        return Task.CompletedTask;
                    }
                }
                else
                {
                   // _logger.LogError("account_has_been_locked {0} {1}", userInfo.IdKhoa, userInfo.UserName);
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "account_has_been_locked", new Dictionary<string, object>
                    {
                        {"lockEnd", userInfo.LockoutEnd.Value }
                    });
                }
                return Task.CompletedTask;
            }
            var isValidPassword = ValidatePassword(userInfo, context.UserName, context.Password, out totalFailCount);
            if (!isValidPassword)
            {
               // _logger.LogError("invalid_username_or_password {0} {1}", userInfo.IdKhoa, userInfo.UserName);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid_username_or_password", new Dictionary<string, object>
                {
                    {"failCount", totalFailCount }
                });
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult(userInfo.IdAccount, OidcConstants.AuthenticationMethods.Password);
            return Task.CompletedTask;
        }

        private bool ValidatePassword(UserAccount userAccount, string userName, string password, out int totalFailCount)
        {
            if (userAccount.UserName.ToLower() != userName.ToLower())
            {
                totalFailCount = 0;
                return false;
            }

            var passwordHash = Convert.ToBase64String(Generate.GetInputPasswordHash(password.Trim(), userAccount.PasswordSalt));
            if (!passwordHash.Equals(userAccount.PasswordHash))
            {
                // Increase fail count.
                var failCount = userAccount.AccessFailedCount;
                failCount += 1;
                Task.Run(() => _userAccountService.UpdateAccessFailCount(userAccount.IdAccount, userAccount.UserName, userAccount.Type, failCount, userAccount.LockoutEnabled));
                totalFailCount = failCount;
                return false;
            }
            if (userAccount.AccessFailedCount > 0)
            {
                Task.Run(() => _userAccountService.UpdateAccessFailCount(userAccount.IdAccount, userAccount.UserName, userAccount.Type, 0, userAccount.LockoutEnabled));
            }
            totalFailCount = 0;
            return true;
        }
    }
}

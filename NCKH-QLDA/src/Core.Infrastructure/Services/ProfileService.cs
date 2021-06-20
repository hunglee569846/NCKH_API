using Core.Domain.IRepository;
using Core.Domain.Models;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Caching.Memory;
using NCKH.Infrastruture.Binding.Helpers;
using NCKH.Infrastruture.Binding.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Infrastructure.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ITenantLanguageRepository _tenantLanguageRepository;
        private readonly IMemoryCache _cache;

        public ProfileService(IUserAccountRepository userAccountRepository, ITenantLanguageRepository tenantLanguageRepository, IMemoryCache cache)
        {
            _userAccountRepository = userAccountRepository;
            _tenantLanguageRepository = tenantLanguageRepository;
            _cache = cache;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            string cacheKeyuserInfo = $"userInfo:{sub}";
            var userInfo = await _cache.GetOrCreateAsync(cacheKeyuserInfo
            , async x =>
            {
                x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                return await _userAccountRepository.GetInfoAsync(sub);
            });

            string cacheKeyisAdmin = $"isAdmin:{sub}";
            var isAdmin = await _cache.GetOrCreateAsync(cacheKeyisAdmin
           , async x =>
           {
               x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
               return await _userAccountRepository.CheckIsAdminAsync(sub);
           });


            //string cachelanguagesInfo = $"languages:{userInfo.TenantId}";
            //var languages = await _cache.GetOrCreateAsync(cachelanguagesInfo
            //, async x =>
            //{
            //    x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            //    return await _tenantLanguageRepository.SelectAllByTenantIdAsync(userInfo.TenantId);
            //});

            var userInfoString = JsonConvert.SerializeObject(new BriefUser
            {
                IdAcount = userInfo.IdAccount,
                MaGiangVien = userInfo.MaGiangVien,
                FullName = userInfo.UserFullName,
                IdBoMon = userInfo.IdBoMon,
                Email = userInfo.Email,
                PhoneNumber = userInfo.PhoneNumber,
                UserName = userInfo.UserName,
                Type = userInfo.Type
            });

            var userInfoEncrypted = EncryptionHelper.Encrypt(userInfoString, userInfo.IdAccount);
            context.IssuedClaims.Add(new Claim("ui", userInfoEncrypted));

            if (isAdmin)
            {
                context.IssuedClaims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                context.IssuedClaims.Add(new Claim(ClaimTypes.Role, "user"));
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            string cacheKey = $"userInfo:{sub}";
            var userInfo = await _cache.GetOrCreateAsync(cacheKey
            , async x =>
            {
                x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                return await _userAccountRepository.GetInfoAsync(sub);
            });

            context.IsActive = userInfo != null;
        }
    }
}

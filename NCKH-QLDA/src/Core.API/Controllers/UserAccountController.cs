using Core.Domain.IServices;
using Core.Domain.ModelMeta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class UserAccountController : CoreApiControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [SwaggerOperation(Summary = "Insert information userAccount.", Description = "Requires login verification!", OperationId = "InsertUserAccount", Tags = new[] { "UserAccount" })]
        [AcceptVerbs("POST"), Route("acount")]
        public async Task<IActionResult> InsertAsync([FromBody]UserAccountInsertMeta userAccountMeta)
        {
            var result = await _userAccountService.InsertAsync(userAccountMeta,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.Type,CurrentUser.UserName);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[SwaggerOperation(Summary = "Insert information userAccount.", Description = "Requires login verification!", OperationId = "InsertUserAccount", Tags = new[] { "UserAccount" })]
        //[AcceptVerbs("GET"), Route("GetInfoByUserNameAsync")]
        //public async Task<IActionResult> GetInfoByUserNameAsync([FromBody] UserAccountInsertMeta userAccountMeta)
        //{
        //    var result = await _userAccountService.(userAccountMeta);
        //    if (result.Code <= 0)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}

        [SwaggerOperation(Summary = "Lưu thông tin tài khoản", Description = "Requires login verification!", OperationId = "ChangePassword", Tags = new[] { "UserAccount" })]
        [Route("change-password"), AcceptVerbs("PUT")]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordMeta updatePasswordMeta)
        {
            var result = await _userAccountService.UpdatePasswordAsync(CurrentUser.IdAcount,CurrentUser.MaGiangVien, CurrentUser.FullName, updatePasswordMeta);
            if (result.Code < 0)
            {
                //_logger.LogError("Change Password userAccount controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sach tai khoan theo bộ môn", Description = "Requires login verification!", OperationId = "ListAccountByBoMon", Tags = new[] { "UserAccount" })]
        [Route("GetListAccount/{idBoMon}"), AcceptVerbs("GET")]
        public async Task<IActionResult> GetAccountByBoMon(string idBoMon)
        {
            var result = await _userAccountService.GetTaiKhoanByBoMon(idBoMon);
            if (result.Code < 0)
            {
                //_logger.LogError("Change Password userAccount controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}

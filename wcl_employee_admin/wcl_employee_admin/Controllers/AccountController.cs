using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories;



namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class AccountController : BaseController
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }

        [HttpGet("GetUserList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var list = await accountRepo.GetAllAccountAsync();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserDetail")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> GetAccountByUsername(string Username)
        {
            try
            {
                var userDetail = await accountRepo.GetAccountAsync(Username);
                return Ok(userDetail);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("SignUp")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel signUpModel)
        {

            var result = await accountRepo.SignUpAsync(signUpModel);
            if (!result.Action_Result)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {

            var result = await accountRepo.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result.Message))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        //[HttpPost("ChangePassWord")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        //public async Task<IActionResult> ChangePassword(ChangePassModel model)
        //{
        //    var result = await accountRepo.UserChangePasswordAsync(model);

        //    if (string.IsNullOrEmpty(result.Message) == false)
        //    {
        //        return NotFound(result);
        //    }
        //    return Ok(result);
        //}

        [HttpPost("UserChangePassWord")]
        [Authorize]
        public async Task<IActionResult> UserChangePassword(ChangePassModel model)
        {
            var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            if (UserNameClaim != null)
            {
                if (UserNameClaim == model.Username)
                {
                    var result = await accountRepo.UserChangePasswordAsync(model);
                    if (string.IsNullOrEmpty(result.Message) == false)
                    {
                        return Unauthorized();
                    }
                    return Ok(result);
                }
            }
            return Unauthorized();
        }


        [HttpDelete("DeletePassWord")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> DeletePassword(DisableAccModel model)
        {
            var result = await accountRepo.DeleteAcountAsync(model);

            return Ok(result);
        }

        //[HttpPost("UpFile")]
        //[AllowAnonymous]
        //public async Task<IActionResult> UploadFile([FromForm] UploadAvatarCreateRequest request)
        //{
        //    try
        //    {   
        //        //var userID = GetUserId(request.UserName);
        //        var check = request;
        //        if (request.UserName != null)
        //        {
        //            //request.UserName = userID;
        //            var result = await accountRepo.UpPhotoAcountAsync(request);
        //            if (!result)
        //            {
        //                return NotFound(result);
        //            }

        //            return Ok(result);

        //        }
        //        return Unauthorized();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

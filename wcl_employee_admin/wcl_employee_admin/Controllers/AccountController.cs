﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Security.Claims;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories;
using Microsoft.Extensions.Configuration;

namespace wcl_employee_admin.Controllers


{
    [Route("api/[controller]")]
    [ApiController]


    public class AccountController : BaseController
    {

        private readonly IConfiguration configuration;
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo, IConfiguration iConfig)
        {
            accountRepo = repo;
            configuration = iConfig;
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

        [HttpGet("GetUserDetail/{Username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> GetAccountByUsername(string Username)
        {
            try
            {
                var userDetail = await accountRepo.GetAccountAsync(Username);
                if (userDetail.Photourl != null)
                {
                    string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                    //userDetail.Photos = userDetail.Photourl ;
                    userDetail.Photourl = baseURL + "/ProfileImg/" + userDetail.Username + "/" + userDetail.Photourl;

                }
                return Ok(userDetail);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("UpdateUserDetail/{Username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> UpdateAccountByUsername([FromForm] SignUpModel editmodal, string Username)
        {
            try
            {
                var result = await accountRepo.UpdateAccountAsync(editmodal, Username);
                return Ok(result);
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
            try
            {
                var result = await accountRepo.SignUpAsync(signUpModel);
                if (!result.Action_Result)
                {
                    return Unauthorized(result);
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
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
                    if ((result.Action_Result) == false)
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


    }
}
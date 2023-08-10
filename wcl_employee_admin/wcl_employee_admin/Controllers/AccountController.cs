using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Security.Claims;
using wcl_employee_admin.Models;
using Microsoft.Extensions.Configuration;
using wcl_employee_admin.Repositories.AccountRepository;
using NuGet.Common;

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

        [HttpGet("GetCoWorkerList")]
        [Authorize]
        public async Task<IActionResult> GetCoWorkerAccount()
        {
            try
            {
                var list = await accountRepo.GetAllAccountAsync();
                var userList = list.Select((acc, index) => new { username = acc.Username, nickName = acc.Nickname, mail = acc.Email });
                return Ok(userList.OrderBy(ob => ob.username));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetManagerList")]
        [Authorize]
        public async Task<IActionResult> GetManagerAccount()
        {
            try
            {
                var list = await accountRepo.GetAllAccountAsync();
                var managerList = list.Where(model => model.Position == "CEO" || model.Position == "Operator" || model.Position == "Manager" || model.Position == "Lead").ToList();
                var managerListCheck = managerList.Select((acc, index) => new { username = acc.Username, mail = acc.Email });
                return Ok(managerListCheck.OrderBy(ob => ob.username));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserList/{Group}")]
        public async Task<IActionResult> GetAccountByGroup(string Group)
        {
            try
            {
                var list = await accountRepo.GetGroupAccountAsync(Group);
                var groupEmployeesList = list.GroupBy(x => x.Department);
                return Ok(groupEmployeesList.Select(dpm => new
                {
                    department = dpm.Key,
                    user = dpm.ToList()
                }));
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
                    userDetail.Photourl = baseURL + "/ProfileImg/" + userDetail.Username + "/" + userDetail.Photourl;
                }
                if (userDetail.Avatarurl != null)
                {
                    string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                    userDetail.Avatarurl = baseURL + "/Avatar/" + userDetail.Username + "/" + userDetail.Avatarurl;
                }
                return Ok(userDetail);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserDetail_notHR/{Username}")]
        [Authorize]
        public async Task<IActionResult> GetAccountByUsername_user(string Username)
        {
            try
            {
                if (Username == User.FindFirst(ClaimTypes.Name)?.Value)
                {
                    var userDetail = await accountRepo.GetAccountAsync(Username);
                    if (userDetail.Photourl != null)
                    {
                        string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                        userDetail.Photourl = baseURL + "/ProfileImg/" + userDetail.Username + "/" + userDetail.Photourl;
                    }
                    if (userDetail.Avatarurl != null)
                    {
                        string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                        userDetail.Avatarurl = baseURL + "/Avatar/" + userDetail.Username + "/" + userDetail.Avatarurl;
                    }
                    return Ok(userDetail);
                }
                else return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("UpdateUserDetail/{ID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> UpdateAccountByID([FromForm] SignUpModel editmodal, string ID)
        {
            try
            {
                var result = await accountRepo.UpdateAccountAsync(editmodal, ID);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateUserAvatar/{ID}")]
        [Authorize]
        public async Task<IActionResult> UpdateAccountByID(IFormFile editURL, string ID)
        {
            try
            {
                var result = await accountRepo.UpdateAvatarUrlAsync(editURL, ID);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("SignUp")]

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
        public async Task<IActionResult> UserChangePassword(ChangePassModal model)
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
        public async Task<IActionResult> DeletePassword(DisableAccModal model)
        {
            var result = await accountRepo.DeleteAcountAsync(model);

            return Ok(result);
        }


    }
}
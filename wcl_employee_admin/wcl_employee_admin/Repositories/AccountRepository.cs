using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        [Obsolete]
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AccountRepository
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            
        }

        public async Task<ResultFeedBack> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);


            if (user == null)
            {
                return new ResultFeedBack() { Action_Result = false, Message = "User account not exist." };
            }
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                return new ResultFeedBack() { Action_Result = false, Message = "Login fail." };
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Position),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };


            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            var AuthorizationJWT = new JwtSecurityTokenHandler().WriteToken(token);
            var dataUser = new DataUser()
            {
                Username = user.UserName,
                Position = user.Position
            };
            var resultData = new ResultFeedBack()
            {
                Action_Result = string.IsNullOrEmpty(AuthorizationJWT) ? false : true,
                Message = string.IsNullOrEmpty(AuthorizationJWT) ? "Login fail." : "Login success.",
                dataUser = dataUser,
                token_user = AuthorizationJWT
            };
            return resultData;
        }

        public async Task<ResultFeedBack> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                PhotoUrl = model.Photos.FileName,
                UserName = model.UserName,
                FullName = model.FullName,
                Phone = model.Phone,
                ZIPCode = model.ZIPCode,
                EEO = model.EEO,
                Position = model.Position,
                Gender = model.Gender,
                ConfirmNumber = model.ConfirmNumber,
                CardNumber = model.CardNumber,
                netSalary = model.netSalary,
                grossSalary = model.grossSalary,
                Note = model.Note,
                NickName = model.NickName,
                Email = model.Email,
                Address = model.Address,
                Location = model.Location,
                Department = model.Department,
                ContractType = model.ContractType,
                BirthDay = model.BirthDay,
                Marital = model.Marital,
                DateStart = model.DateStart,
                Passport = model.Passport,
            };
            var identityResult = await userManager.CreateAsync(user, model.Password);

                if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "AvatarImg")))
                {
                    Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "AvatarImg", model.UserName));
                }

                FileUpload.FileUpload.SingleFileCurrentProject(model.Photos, _hostingEnvironment.WebRootPath, Path.Combine("AvatarImg", model.UserName, ""), model.Photos.FileName);

            return new ResultFeedBack() { Action_Result = identityResult.Succeeded, Message = identityResult.Succeeded ? "SignUp Success." : "SignUp Fail." };
        }

        public async Task<ResultFeedBack> UpdateAcountAsync(ChangePassModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new ResultFeedBack() { Action_Result = false, Message = "This User not exist." };
            }
            if (model.NewPassword == model.ConfirmNewPassword)
            {
                var result2 = await userManager.CheckPasswordAsync(user, model.CurrentPassword);
                if (result2 == true)
                {
                    var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded) return new ResultFeedBack() { Action_Result = true, Message = "This User's Password has been changed." };
                }
            }
            return new ResultFeedBack() { Action_Result = false, Message = "Change password fail." };
        }


        public async Task<ResultFeedBack> DeleteAcountAsync(DisableAccModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new ResultFeedBack() { Action_Result = false };
            }
            else {
                var delacc = await userManager.DeleteAsync(user);
                if (delacc.Succeeded)
                {
                    return new ResultFeedBack() { Action_Result = true, Message = "Password has been deleted." };
                }

            }
            return new ResultFeedBack() { Action_Result = false, Message = "Deleting Password failed." };
        }

    }
}

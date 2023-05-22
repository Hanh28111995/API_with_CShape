using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        [Obsolete]
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AccountRepository
        (
            FormContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _mapper = mapper;

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
                Photourl = (model.Photos != null) ? model.Photos.FileName : null,
                UserName = model.Username,
                Fullname = model.Fullname,
                Phone = model.Phone,
                Zipcode = model.Zipcode,
                Eeo = model.Eeo,
                Position = model.Position,
                Gender = model.Gender,
                Confirmnumber = model.Confirmnumber,
                Cardnumber = model.Cardnumber,
                Netsalary = model.Netsalary,
                Grosssalary = model.Grosssalary,
                Note = model.Note,
                Nickname = model.Nickname,
                Email = model.Email,
                Address = model.Address,
                Location = model.Location,
                Department = model.Department,
                Contracttype = model.Contracttype,
                Birthday = model.Birthday,
                Marital = model.Marital,
                Datestart = model.Datestart,
                Passport = model.Passport,
                Status = model.Status,
            };

            if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.Username)))
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.Username));
            }
            //if (Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName)))
            //{
            //    FileUpload.FileUpload.DeleteFile(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", ""));
            //    Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName));
            //}

            if (model.Photos != null)
            {
                FileUpload.FileUpload.SingleFileCurrentProject(model.Photos, _hostingEnvironment.WebRootPath, Path.Combine("ProfileImg", model.Username, ""), model.Photos.FileName);
            }
            else
            {
                var genderImg = (model.Gender == "Female") ? "woman.png" : "man.png";
                var pathDefault = Path.Combine(_hostingEnvironment.WebRootPath, "avatarDefault", genderImg);
                File.Copy(pathDefault, Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.Username, genderImg));
                user.Photourl = genderImg;
            }

            var identityResult = await userManager.CreateAsync(user, model.Password);

            return new ResultFeedBack() { Action_Result = identityResult.Succeeded, Message = identityResult.Succeeded ? "SignUp Success." : identityResult.Errors.First().Description };
        }

        public async Task<ResultFeedBack> UserChangePasswordAsync(ChangePassModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new ResultFeedBack() { Action_Result = false, Message = "This User not exist." };
            }
            if (model.NewPassword == model.ConfirmNewPassword)
            {
                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded) return new ResultFeedBack() { Action_Result = true, Message = "This User's Password has been changed." };
                else return new ResultFeedBack() { Action_Result = false, Message = "Change password fail." };
            }
            else
                return new ResultFeedBack() { Action_Result = false, Message = "Confirm New Password not correct." };

        }

        public async Task<List<UserForm>> GetAllAccountAsync()
        {
            var forms = await userManager.Users.ToListAsync();
            return _mapper.Map<List<UserForm>>(forms);
        }

        public async Task<UserDetail> GetAccountAsync(string Username)
        {
            var form = await userManager.FindByNameAsync(Username);

            return _mapper.Map<UserDetail>(form);
        }


        public async Task<ResultFeedBack> DeleteAcountAsync(DisableAccModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new ResultFeedBack() { Action_Result = false };
            }
            else
            {
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

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.AccountRepository
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
            IWebHostEnvironment hostingEnvironment
        )
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
                new Claim(ClaimTypes.GroupSid, user.Department),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };


            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(4 * 60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            var AuthorizationJWT = new JwtSecurityTokenHandler().WriteToken(token);
            var dataUser = new DataUser()
            {
                Username = user.UserName,
                Position = user.Position,
                Department = user.Department
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
                Photourl = model.Photos != null ? model.Photos.FileName : ((model.Gender == "Male") ? "man.png" : "woman.png"),
                Avatarurl = model.Avatar != null ? model.Avatar.FileName : "avatar_default.jpg",
                UserName = model.UserName,
                Fullname = model.Fullname ?? "",
                Passport = model.Passport ?? "",
                Nickname = model.Nickname ?? "",
                Eeo = model.Eeo ?? "",
                Location = model.Location ?? "",
                Department = model.Department ?? "",
                Contracttype = model.Contracttype ?? "",
                Marital = model.Marital ?? "",
                Email = model.Email ?? "",
                Phone = model.Phone ?? "",
                Address = model.Address ?? "",
                Zipcode = model.Zipcode ?? "",
                Position = model.Position ?? "",
                Status = model.Status ?? "",
                Departmentroles = model.Departmentroles ?? "",
                Gender = model.Gender ?? "",
                Confirmnumber = model.Confirmnumber ?? "",
                Birthday = model.Birthday,
                Cardnumber = model.Cardnumber ?? "",
                Datestart = model.Datestart,
                Sha = model.Sha ?? 0,
                Vha = model.Vha ?? 0,
                Dkp = model.Dkp ?? 0,
                Netsalary = model.Netsalary ?? 0,
                Grosssalary = model.Grosssalary ?? 0,
                Datecreated = model.Datecreated,
                Note = model.Note ?? "",
            };

            var identityResult = await userManager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
                if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", model.UserName)))
                {
                    Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", model.UserName));
                }
                if (model.Avatar != null)
                {
                    FileUpload.FileUpload.SingleFileCurrentProject(model.Avatar, _hostingEnvironment.WebRootPath, Path.Combine("Avatar", model.UserName, ""), model.Avatar.FileName);
                }
                else
                {
                    var avatar_Df = "avatar_default.jpg";
                    var pathDefault = Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", avatar_Df);
                    File.Copy(pathDefault, Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", model.UserName, avatar_Df));
                    user.Avatarurl = avatar_Df;
                }


                if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName)))
                {
                    Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName));
                }
                if (model.Photos != null)
                {
                    FileUpload.FileUpload.SingleFileCurrentProject(model.Photos, _hostingEnvironment.WebRootPath, Path.Combine("ProfileImg", model.UserName, ""), model.Photos.FileName);
                }
                else
                {
                    var genderImg = model.Gender == "Female" ? "woman.png" : "man.png";
                    var pathDefault = Path.Combine(_hostingEnvironment.WebRootPath, "avatarDefault", genderImg);
                    File.Copy(pathDefault, Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName, genderImg));
                    user.Photourl = genderImg;
                }
            }
            return new ResultFeedBack() { Action_Result = identityResult.Succeeded, Message = identityResult.Succeeded ? "SignUp Success." : identityResult.Errors.First().Description };
        }

        public async Task<ResultFeedBack> UserChangePasswordAsync(ChangePassModal model)
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

        public async Task<List<GroupUserForm>> GetGroupAccountAsync(string Group)
        {
            var forms = await userManager.Users.Where(u => u.Position == Group).ToListAsync();

            return _mapper.Map<List<GroupUserForm>>(forms);
        }


        public async Task<UserDetail> GetAccountAsync(string Username)
        {
            var form = await userManager.FindByNameAsync(Username);
            return _mapper.Map<UserDetail>(form);
        }


        public async Task<ResultFeedBack> UpdateAvatarUrlAsync(IFormFile editURL, string ID)
        {
            var form = await userManager.FindByIdAsync(ID);
            
            form.Avatarurl = editURL != null ? editURL.FileName : "avatar_default.jpg";

            if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName)))
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName));
            }

            if (editURL != null)
            {
                Directory.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName), true);
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName));
                FileUpload.FileUpload.SingleFileCurrentProject(editURL, _hostingEnvironment.WebRootPath, Path.Combine("Avatar", form.UserName, ""),editURL.FileName);
            }
            else
            {
                Directory.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName), true);
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName));
                var dfImg = "avatar_default.jpg";
                var pathDefault = Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", dfImg);
                File.Copy(pathDefault, Path.Combine(_hostingEnvironment.WebRootPath, "Avatar", form.UserName, dfImg));
            }
            var result = await userManager.UpdateAsync(form);
            return new ResultFeedBack() { Action_Result = result.Succeeded, Message = result.Succeeded ? "Edit User Success." : result.Errors.First().Description };
        }

        public async Task<ResultFeedBack> UpdateAccountAsync(SignUpModel model, string ID)
        {
            var form = await userManager.FindByIdAsync(ID);
            form.Fullname = model.Fullname ?? "";
            form.Passport = model.Passport ?? "";
            form.Nickname = model.Nickname ?? "";
            form.Eeo = model.Eeo ?? "";
            form.Location = model.Location ?? "";
            form.Department = model.Department ?? "";
            form.Contracttype = model.Contracttype ?? "";
            form.Marital = model.Marital ?? "";
            form.Email = model.Email ?? "";
            form.Phone = model.Phone ?? "";
            form.Address = model.Address ?? "";
            form.Zipcode = model.Zipcode ?? "";
            form.Position = model.Position ?? "";
            form.Status = model.Status ?? "";
            form.Departmentroles = model.Departmentroles ?? "";
            form.Gender = model.Gender ?? "";
            form.Confirmnumber = model.Confirmnumber ?? "";
            form.Birthday = model.Birthday;
            form.Cardnumber = model.Cardnumber ?? "";
            form.Datestart = model.Datestart;
            form.Sha = model.Sha ?? 0;
            form.Vha = model.Vha ?? 0;
            form.Dkp = model.Dkp ?? 0;
            form.Netsalary = model.Netsalary ?? 0;
            form.Grosssalary = model.Grosssalary ?? 0;
            form.Datecreated = model.Datecreated;
            form.Note = model.Note ?? "";
            form.Photourl = model.Photos != null ? model.Photos.FileName : ((model.Gender == "Male") ? "man.png" : "woman.png");
            form.Avatarurl = model.Avatar != null ? model.Avatar.FileName : "defaultAvatar.png";

            if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName)))
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName));
            }


            if (model.Photos != null)
            {
                Directory.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName), true);
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName));
                FileUpload.FileUpload.SingleFileCurrentProject(model.Photos, _hostingEnvironment.WebRootPath, Path.Combine("ProfileImg", model.UserName, ""), model.Photos.FileName);
            }
            else
            {
                Directory.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName), true);
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName));
                var genderImg = model.Gender == "Female" ? "woman.png" : "man.png";
                var pathDefault = Path.Combine(_hostingEnvironment.WebRootPath, "avatarDefault", genderImg);
                File.Copy(pathDefault, Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImg", model.UserName, genderImg));
            }

           
            var result = await userManager.UpdateAsync(form);
            return new ResultFeedBack() { Action_Result = result.Succeeded, Message = result.Succeeded ? "Edit User Success." : result.Errors.First().Description };
        }


        public async Task<ResultFeedBack> DeleteAcountAsync(DisableAccModal model)
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

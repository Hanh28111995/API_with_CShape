using Microsoft.AspNetCore.Identity;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        public Task<ResultFeedBack> SignUpAsync(SignUpModel model);
        public Task<ResultFeedBack> SignInAsync(SignInModel model);
        public Task<ResultFeedBack> UserChangePasswordAsync(ChangePassModal model);
        public Task<ResultFeedBack> DeleteAcountAsync(DisableAccModal model);
        public Task<List<UserForm>> GetAllAccountAsync();
        public Task<List<GroupUserForm>> GetGroupAccountAsync(string Group);
        public Task<UserDetail> GetAccountAsync(string Username);
        public Task<ResultFeedBack> UpdateAccountAsync(SignUpModel model, string ID);

    }
}

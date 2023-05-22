﻿using Microsoft.AspNetCore.Identity;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public interface IAccountRepository
    {
        public Task<ResultFeedBack> SignUpAsync(SignUpModel model);
        public Task<ResultFeedBack> SignInAsync(SignInModel model);
        public Task<ResultFeedBack> UserChangePasswordAsync(ChangePassModel model);
        public Task<ResultFeedBack> DeleteAcountAsync(DisableAccModel model);

        public Task<List<UserForm>> GetAllAccountAsync();
        public Task<UserDetail> GetAccountAsync( string Username);


    }
}

﻿using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public interface ITimeOffFormRepository

    {
        public Task<List<TimeOffFormModal>> getAllFormsAsync();
        public Task<TimeOffFormModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(TimeOffFormModal model);
        public Task<ResultFeedBack> UpdateFormAsync(TimeOffFormModal model);
        public Task DeleteFormAsync(int ID);
    }
}

﻿using wcl_employee_admin.Data;
using wcl_employee_admin.Models;

namespace wcl_employee_admin.Repositories
{
    public interface ITimeOffFormRepository

    {
        public Task<List<TimeOffFormModal>> getAllFormsAsync();
        public Task<TimeOffFormModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(TimeOffFormModal model);
        public Task UpdateFormAsync(TimeOffFormModal model);
        public Task DeleteFormAsync(int ID);
    }
}

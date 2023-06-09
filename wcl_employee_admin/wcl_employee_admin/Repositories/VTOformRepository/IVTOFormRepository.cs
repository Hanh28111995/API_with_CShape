﻿using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.VTOformRepository
{
    public interface IVTOFormRepository

    {
        public Task<List<VTO_FormModal>> getAllFormsAsync();
        public Task<List<VTO_FormModal>> getGroupFormsAsync(string group);
        public Task<VTO_FormModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(VTO_FormModal model);
        public Task<ResultFeedBack> UpdateFormAsync(VTO_FormModal model);
        public Task DeleteFormAsync(int ID);
    }
}

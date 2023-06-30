using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.InjuryReportRepository
{
    public interface IInjuryReportFormRepository

    {
        public Task<List<InjuryReportFormModal>> getAllFormsAsync();
        public Task<InjuryReportFormModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(InjuryReportFormModal model);
        public Task<ResultFeedBack> UpdateFormAsync(InjuryReportFormModal model);
        public Task DeleteFormAsync(int ID);
    }
}
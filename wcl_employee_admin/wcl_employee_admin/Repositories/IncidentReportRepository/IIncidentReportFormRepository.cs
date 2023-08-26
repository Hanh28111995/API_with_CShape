using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.IncidentReportRepository
{
    public interface IIncidentReportFormRepository

    {
        public Task<List<IncidentReportFormModal>> getAllFormsAsync();

        public Task<List<IncidentReportFormModal>> getGroupFormsAsync(string group);
        public Task<IncidentReportFormModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(IncidentReportFormModal model);
        public Task<ResultFeedBack> UpdateFormAsync(IncidentReportFormModal model);
        public Task DeleteFormAsync(int ID);
    }
}

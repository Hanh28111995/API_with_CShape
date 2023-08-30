using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.LunchCorrectionRepository
{
    public interface ILunchCorrectionFormRepository

    {
        public Task<List<LunchCorrectionFormModal>> getAllFormsAsync();
        public Task<LunchCorrectionFormModal> getFormAsync(int ID);
        public Task<List<LunchCorrectionFormModal>> getGroupFormsAsync(string group);
        public Task<int> AddFormAsync(LunchCorrectionFormModal model);
        public Task<ResultFeedBack> UpdateFormAsync(LunchCorrectionFormModal model);
        public Task DeleteFormAsync(int ID);
    }
}

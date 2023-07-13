using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.TimeSheetRepository
{
    public interface ITimeSheetRepository

    {
        public Task<List<TimeSheetModal>> getAllFormsAsync();
        public Task<List<TimeSheetModal>> getGroupFormsAsync(string group);
        public Task<TimeSheetModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(TimeSheetModal model);
        public Task<ResultFeedBack> UpdateFormAsync(TimeSheetModal model);
        public Task DeleteFormAsync(int ID);
    }
}

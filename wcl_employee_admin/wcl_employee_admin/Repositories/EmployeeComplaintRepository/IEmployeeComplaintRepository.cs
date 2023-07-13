using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.EmployeeComplaintRepository
{
    public interface IEmployeeComplaintRepository
    {
        public Task<List<EmployeeComplaintModal>> getAllFormsAsync();
        public Task<List<EmployeeComplaintModal>> getGroupFormsAsync(string group);
        public Task<EmployeeComplaintModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(EmployeeComplaintModal model);
        public Task<ResultFeedBack> UpdateFormAsync(EmployeeComplaintModal model);
        public Task DeleteFormAsync(int ID);
    }
}



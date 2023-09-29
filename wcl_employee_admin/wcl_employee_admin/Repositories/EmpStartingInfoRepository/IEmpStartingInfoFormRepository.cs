using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.EmpStartingInfoRepository
{
    public interface IEmpStartingInfoFormRepository


    {
        public Task<List<EmpStartingInforModal>> getAllFormsAsync();
        public Task<EmpStartingInforModal> getFormAsync(int ID);
        public Task<int> AddFormAsync(EmpStartingInforModal model);
        public Task<ResultFeedBack> UpdateFormAsync(EmpStartingInforModal model);
        public Task DeleteFormAsync(int ID);
    }
}

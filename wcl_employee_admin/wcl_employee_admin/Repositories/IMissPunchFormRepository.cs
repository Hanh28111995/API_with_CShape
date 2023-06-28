using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public interface IMissPunchFormRepository

    {
       public Task<List<MissPunchFormModal>> getAllFormsAsync();
       public Task<MissPunchFormModal> getFormAsync(int ID);
       public Task<int> AddFormAsync(MissPunchFormModal model);
       public Task<ResultFeedBack>  UpdateFormAsync(MissPunchFormModal model);
       public Task  DeleteFormAsync(int ID);
    }
}

using wcl_employee_admin.Data;
using wcl_employee_admin.Models;

namespace wcl_employee_admin.Repositories
{
    public interface IMissPunchFormRepository

    {
       public Task<List<MissPunchFormModal>> getAllFormsAsync();
       public Task<MissPunchFormModal> getFormAsync(int ID);
       public Task<int> AddFormAsync(MissPunchFormModal model);
       public Task UpdateFormAsync(MissPunchFormModal model);
       public Task DeleteFormAsync(int ID);
    }
}

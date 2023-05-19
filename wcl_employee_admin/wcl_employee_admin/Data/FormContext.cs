using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace wcl_employee_admin.Data
{
    public class FormContext: IdentityDbContext<ApplicationUser>
    {
        public FormContext(DbContextOptions<FormContext> options): base(options) 
        {

        }
        #region DBSet
        public DbSet<TimeOffForm>? TimeOffForms { get; set; }
        public DbSet<MissPunchForm>? MissPunchForms { get; set; }
        #endregion
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Models;

namespace wcl_employee_admin.Data
{
    public class FormContext: IdentityDbContext<ApplicationUser>
    {
        public FormContext(DbContextOptions<FormContext> options): base(options) 
        {
        }
        #region DBSet
        public DbSet<InjuryReportForm> InjuryReportForms { get; set; }
        public DbSet<IncidentReportForm> IncidentReportForms { get; set; }
        public DbSet<VTO_Form> vtoForms { get; set; }
        public DbSet<TimeOffForm> TimeOffForms { get; set; }
        public DbSet<MissPunchForm> MissPunchForms { get; set; }
        public DbSet<LunchCorrectionForm> LunchCorrectionForms { get; set; }
        public DbSet<EmployeeComplaintForm> employeeComplaintForms { get; set; }
        public DbSet<TimeSheetForm> timeSheetForm { get; set; }
        public DbSet<EmpStartingInfoForm> empStartingInfor { get; set; }

        #endregion
    }
}

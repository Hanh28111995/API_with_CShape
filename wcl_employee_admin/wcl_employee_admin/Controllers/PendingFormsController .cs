using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Models;

using wcl_employee_admin.Repositories.TimeOffRepository;
using wcl_employee_admin.Repositories.MissPunchRepository;
using wcl_employee_admin.Repositories.LunchCorrectionRepository;
using wcl_employee_admin.Repositories.IncidentReportRepository;
using wcl_employee_admin.Repositories.EmployeeComplaintRepository;
using wcl_employee_admin.Repositories.VTOformRepository;
using wcl_employee_admin.Repositories.InjuryReportRepository;
using NuGet.Protocol.Core.Types;
using System.Threading;
using wcl_employee_admin.ViewModel;
using System.Linq;

namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingFormsController : ControllerBase
    {
        private readonly ITimeOffFormRepository _TimeOffFormRepo;
        private readonly IMissPunchFormRepository _MissPunchFormRepo;
        private readonly ILunchCorrectionFormRepository _LunchCorrectionFormRepo;
        private readonly IIncidentReportFormRepository _IncidentReportFormRepo;
        private readonly IEmployeeComplaintRepository _EmployeeComplaintFormRepo;
        private readonly IVTOFormRepository _VTOFormRepo;
        private readonly IInjuryReportFormRepository _InjuryReportFormRepo;

        public PendingFormsController(
            ITimeOffFormRepository TimeOffFormRepo,
            IMissPunchFormRepository MissPuchFormRepo,
            ILunchCorrectionFormRepository LunchCorrectionFormRepo,
            IIncidentReportFormRepository IncidentReportFormRepo,
            IEmployeeComplaintRepository EmployeeComplaintFormRepo,
            IVTOFormRepository VTOFormRepo,
            IInjuryReportFormRepository InjuryReportFormRepo
            )
        {
            _TimeOffFormRepo = TimeOffFormRepo;
            _MissPunchFormRepo = MissPuchFormRepo;
            _LunchCorrectionFormRepo = LunchCorrectionFormRepo;
            _IncidentReportFormRepo = IncidentReportFormRepo;
            _EmployeeComplaintFormRepo = EmployeeComplaintFormRepo;
            _VTOFormRepo = VTOFormRepo;
            _InjuryReportFormRepo = InjuryReportFormRepo;
        }

        [HttpGet("getPending_status/")]

        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                var position = User.FindFirst(ClaimTypes.Role)?.Value;
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var TimeOffPending = await _TimeOffFormRepo.getAllFormsAsync();
                
                var MissPunchPending = await _MissPunchFormRepo.getAllFormsAsync();
                var LunchCorrectionPending = await _LunchCorrectionFormRepo.getAllFormsAsync();
                var IncidentReportPending = await _IncidentReportFormRepo.getAllFormsAsync();
                var EmployeeComplaintPending = await _EmployeeComplaintFormRepo.getAllFormsAsync();
                var VTOFormPending = await _VTOFormRepo.getAllFormsAsync();
                var InjuryReportPending = await _InjuryReportFormRepo.getAllFormsAsync();

                var CoWorkerPending = TimeOffPending.Where(item => item.CoverWorker == email && item.CoworkerStatus == null).Count();

                if (position == "HR")
                {
                    return Ok(new ObjectPending()
                    {                        
                        PendingTimeOff = TimeOffPending.Where(item => item.HRStatus == null).Count(),
                        PendingMissPunch = MissPunchPending.Where(item => item.HRStatus == null).Count(),
                        PendingLunchCorrection = LunchCorrectionPending.Where(item => item.HRStatus == null).Count(),
                        PendingIncidentReport = IncidentReportPending.Where(item => item.HRStatus == null).Count(),
                        PendingEmployeeComplaint = EmployeeComplaintPending.Where(item => item.HRStatus == null).Count(),
                        PendingVTO = VTOFormPending.Where(item => item.HRStatus == null).Count(),
                        PendingInjuryReport = InjuryReportPending.Where(item => item.HRStatus == null).Count(),
                        CoWorkerPending = CoWorkerPending,
                    });
                }
                else
                {
                    if (position == "Manager")
                    {
                        return Ok(new ObjectPending()
                        {                            
                            PendingTimeOff = TimeOffPending.Where(item => item.ManagerStatus == null).Count(),
                            PendingMissPunch = MissPunchPending.Where(item => item.ManagerStatus == null).Count(),
                            PendingLunchCorrection = LunchCorrectionPending.Where(item => item.ManagerStatus == null).Count(),
                            PendingIncidentReport = IncidentReportPending.Where(item => item.ManagerStatus == null).Count(),
                            PendingEmployeeComplaint = EmployeeComplaintPending.Where(item => item.ManagerStatus == null).Count(),
                            PendingVTO = VTOFormPending.Where(item => item.ManagerStatus == null).Count(),
                            CoWorkerPending = CoWorkerPending,
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            CoWorkerPending = CoWorkerPending,
                        });
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

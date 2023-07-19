using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories.TimeSheetRepository;
using wcl_employee_admin.Repositories.TimeOffRepository;
using System.Text.RegularExpressions;
using wcl_employee_admin.ViewModel;
using Microsoft.AspNetCore.Identity;
using wcl_employee_admin.Data;
//using System.Data.Linq;
//using System.Data.Linq.SqlClient;

namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TimeSheetController : ControllerBase
    {
        private readonly ITimeSheetRepository _formRepo;
        private readonly ITimeOffFormRepository _formTimeOffRepo;

        public TimeSheetController(ITimeSheetRepository repo
            , ITimeOffFormRepository formTimeOffRepo
            )
        {
            _formRepo = repo;
            _formTimeOffRepo = formTimeOffRepo;
        }

        [HttpGet("getTimeSheet/All")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]

        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                var result = await _formRepo.getAllFormsAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpGet("getVTOForm/Manager")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]

        //public async Task<IActionResult> GetGroupForms()
        //{
        //    try
        //    {
        //        var group = User.FindFirst(ClaimTypes.GroupSid)?.Value;
        //        return Ok(await _formRepo.getGroupFormsAsync(group));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


        [HttpGet("getTimeSheet/user")]
        [Authorize]
        public async Task<IActionResult> UserGetAllForms()
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                if (UserNameClaim != null)
                {
                    var allforms = await _formRepo.getAllFormsAsync();
                    var userform = allforms.Where(model => model.Username == UserNameClaim).ToList();
                    return Ok(userform);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpGet("getVTOForm/{Reference}")]
        //[Authorize]
        //public async Task<IActionResult> GetFormbyId(int ID)
        //{
        //    try
        //    {
        //        var Forms = await _formRepo.getFormAsync(ID);
        //        return Forms == null ? NotFound() : Ok(Forms);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}




        [HttpPost("addTimeSheet/addTimeSheetOn")]
        [Authorize]
        public async Task<IActionResult> AddNewFormOn(TimeSheetModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                var UserNameDepartment = User.FindFirst(ClaimTypes.Role)?.Value;
                model.Username = UserNameClaim;
                model.TimeSheet_Department = UserNameDepartment;
                model.TimeSheet_Reference = "TS" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                //model.TimeSheet_Start = DateTime.Now;
                model.DateSubmit = model.TimeSheet_Start;



                var Timeoff_All = await _formTimeOffRepo.getAllFormsAsync();
                var filterByUser = Timeoff_All.Where(dayoff => dayoff.Username == model.Username).ToList();
                var filterByDate = filterByUser.Where(p => (DateTime.Compare(p.TimeOffStart.Value, model.DateSubmit.Value) <= 0) && (DateTime.Compare(p.TimeOffEnd.Value, model.DateSubmit.Value) >= 0) && (p.HRStatus == false)).ToList();
                if (filterByDate.Count() > 0)
                {
                    if (filterByDate[0].ShiftDay == "Full Day")
                    {
                        return Ok();
                    }
                }

                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("addTimeSheet/addTimeSheetSubmitOff")]
        [Authorize]
        public async Task<IActionResult> AddNewFormOff(TimeOffFormModal model)
        {
            var newForm = 0;
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var filterByUser = TimeSheet_All.Where(ts => ts.Username == model.Username).ToList();
            var filterByDate = filterByUser.Where(ts => ts.DateSubmit == model.TimeOffStart).ToList();
            if (filterByDate.Count() > 0)
            {
                return Ok();
            }

            try
            {
                int OffHour;
                if (model.ShiftDay == "Full Day") { OffHour = 8; }
                else { OffHour = 4; }

                if (model.TimeOffStart != model.TimeOffEnd)
                {

                    int numDays = (model.TimeOffEnd.Value - model.TimeOffStart.Value).Days + 1;
                    DateTime[] dates = new DateTime[numDays];
                    for (int i = 0; i < numDays; i++)
                    {
                        dates[i] = model.TimeOffStart.Value.AddDays(i);

                        var TimeSheetOff = new TimeSheetModal
                        {
                            Username = model.Username,
                            DateSubmit = dates[i],
                            TimeSheet_Department = User.FindFirst(ClaimTypes.GroupSid).Value,
                            TimeSheet_Reference = "TS" + dates[i].ToString("yyyyMMdd") + "OFF",
                            TimeSheet_TimeOff_Vacation = ((model.PayType == "Vacation") ? 1 : 0) * OffHour,
                            TimeSheet_TimeOff_Holiday = ((model.PayType == "Holiday") ? 1 : 0) * OffHour,
                            TimeSheet_TimeOff_45Day = ((model.PayType == "45Day") ? 1 : 0) * OffHour,
                            TimeSheet_TimeOff_noWork = ((model.PayType == "noWork") ? 1 : 0) * OffHour,
                            TimeSheet_TimeOff_note = model.Note,
                        };
                        newForm = await _formRepo.AddFormAsync(TimeSheetOff);
                    }
                }
                else
                {
                    var TimeSheetOff = new TimeSheetModal
                    {
                        Username = model.Username,
                        DateSubmit = model.TimeOffStart,
                        TimeSheet_Department = User.FindFirst(ClaimTypes.GroupSid).Value,
                        TimeSheet_Reference = "TS" + model.TimeOffStart.Value.ToString("yyyyMMdd") + "OFF",
                        TimeSheet_TimeOff_Vacation = ((model.PayType == "Vacation") ? 1 : 0) * OffHour,
                        TimeSheet_TimeOff_Holiday = ((model.PayType == "Holiday") ? 1 : 0) * OffHour,
                        TimeSheet_TimeOff_45Day = ((model.PayType == "45Day") ? 1 : 0) * OffHour,
                        TimeSheet_TimeOff_noWork = ((model.PayType == "noWork") ? 1 : 0) * OffHour,
                        TimeSheet_TimeOff_note = model.Note,
                    };
                    newForm = await _formRepo.AddFormAsync(TimeSheetOff);

                }
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("deleteTimeSheet/deleteTimeSheetRejectOff")]
        [Authorize]
        public async Task<IActionResult> DeleteFormOff(TimeOffFormModal model)
        {
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var filterByUser = TimeSheet_All.Where(ts => ts.Username == model.Username).ToList();

            if (model.TimeOffStart != model.TimeOffEnd)
            {
                int numDays = (model.TimeOffEnd.Value - model.TimeOffStart.Value).Days + 1;
                DateTime[] dates = new DateTime[numDays];
                for (int i = 0; i < numDays; i++)
                {
                    dates[i] = model.TimeOffStart.Value.AddDays(i);
                }
                var filterByDate = filterByUser.Where(ts => dates.Contains(ts.DateSubmit.Value));
                //await _formRepo.DeleteFormAsync();

            }
            else
            {
                DateTime date = model.TimeOffStart.Value;
                var filterByDate = filterByUser.Where(ts => date == ts.DateSubmit.Value);
                //await _formRepo.DeleteFormAsync(filterByDate);
            }




            return Ok();
        }



        [HttpPut("ediTimeSheet/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR, Manager")]
        public async Task<IActionResult> UpdateForm(TimeSheetModal model)
        {
            try
            {
                if (model.ID == null)
                {
                    return NotFound();
                }
                var result = await _formRepo.UpdateFormAsync(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("deleteTimeSheet/{ID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> DeleteForm([FromRoute] int ID)
        {
            try
            {
                await _formRepo.DeleteFormAsync(ID);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

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
using System;
using System.Reflection;
using System.Linq;
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

        [HttpGet("getTimeSheet/All")]    ///check
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
                    var ListMissPunch = userform.Where(model => model.TimeSheet_Reference.Contains("MP")).ToList();
                    if (ListMissPunch != null)
                    {
                        List<string> newReference = ListMissPunch.Select(x => x.TimeSheet_Reference).ToList();
                        List<string> newReferenceNoMP = newReference.Select(x => x.Replace("MP", "")).ToList();
                        for(int i = 0;i < newReferenceNoMP.Count;i++)
                        {
                            for(int j = 0;j < userform.Count; j++)
                            {
                                if(userform[j].TimeSheet_Reference == newReferenceNoMP[i]) {
                                    userform.RemoveAt(j);
                                }
                            }
                        }
                    }
                    return Ok(userform);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getTimeSheet/{ID}")]
        [Authorize]
        public async Task<IActionResult> GetTimeSheetbyId(int ID)
        {
            try
            {
                var Forms = await _formRepo.getFormAsync(ID);
                return Forms == null ? NotFound() : Ok(Forms);
            }
            catch
            {
                return BadRequest();
            }
        }





        [HttpPost("addTimeSheet/addTimeSheetOn")]  ////check
        [Authorize]
        public async Task<IActionResult> AddNewFormOn(TimeSheetModal model)
        {
            static DateTime convertDateToNoTime(DateTime? x)
            {
                var new_x = x.GetValueOrDefault().Date;
                return new_x;
            }
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                var UserNameDepartment = User.FindFirst(ClaimTypes.Role)?.Value;
                model.Username = UserNameClaim;
                model.TimeSheet_Department = UserNameDepartment;
                model.TimeSheet_Reference = "TS" + (model.TimeSheet_Start.Value).ToString("yyyyMMdd");
                model.DateSubmit = convertDateToNoTime(model.TimeSheet_Start.Value);

                ////check that if this timesheet-datesubmit has already exist, stop creating New Timesheet
                var TimeSheet_All = await _formRepo.getAllFormsAsync();
                var Count_TimeSheet = TimeSheet_All.Where(ts => ts.TimeSheet_Reference == model.TimeSheet_Reference && ts.Username == model.Username).ToList();
                if (Count_TimeSheet.Count != 0)
                {
                    return Ok(new ResultFeedBack() { Action_Result = true, Message = "TimeSheet has existed." });
                }

                ////check that if the off-timesheet (full time) has existed, stop creating New Timesheet
                var Timeoff_All = await _formTimeOffRepo.getAllFormsAsync();
                var filterByUser = Timeoff_All.Where(dayoff => (dayoff.Username == model.Username && dayoff.HRStatus == true)).ToList();
                var filterByDate = filterByUser.Where(p => (DateTime.Compare(convertDateToNoTime(p.TimeOffStart), convertDateToNoTime(model.DateSubmit)) <= 0) && (DateTime.Compare(p.TimeOffEnd.Value, convertDateToNoTime(p.TimeOffStart)) >= 0)).ToList();
                if (filterByDate.Count() > 0)
                {
                    if (filterByDate[0].ShiftDay == "Full Day")
                    {
                        return Ok(new ResultFeedBack() { Action_Result = true, Message = "TimeSheet has existed." });
                    }
                }

                var newForm = await _formRepo.AddFormAsync(model);

                return Ok(newForm);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("addTimeSheet/addTimeSheetSubmitOff")] ////check
        [Authorize]
        public async Task<IActionResult> AddNew_TS_Off(TimeOffFormModal model)
        {
            var newForm = new ResultFeedBack();
            var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var checkExist = TimeSheet_All.Where(ts => ts.TimeSheet_Reference == ("TS" + model.TimeOffStart.Value.ToString("yyyyMMdd") + "OFF") && ts.Username == UserNameClaim).ToList();

            if (checkExist.Count == 0)
            {

                var filterByDate = TimeSheet_All.FirstOrDefault(ts => ts.Username == model.Username && ts.TimeSheet_Reference == ("TS" + model.TimeOffStart.Value.ToString("yyyyMMdd") + "OFF"));

                if (filterByDate != null)
                {
                    return NotFound();
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
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpPost("addTimeSheet/addTimeSheetSubmitMissPunch")] //check
        [Authorize]
        public async Task<IActionResult> AddNewFormMissPunch(MissPunchFormModal model)
        {
            var newForm = new ResultFeedBack();
            var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var checkExist = TimeSheet_All.Where(ts => ts.TimeSheet_Reference == ("TS" + model.PunchIn.Value.ToString("yyyyMMdd") + "MP") && ts.Username == UserNameClaim).ToList();

            if (checkExist.Count == 0)
            {

                var filterByDate = TimeSheet_All.FirstOrDefault(ts => ts.Username == model.Username && ts.DateSubmit == model.PunchIn);

                if (filterByDate != null)
                {
                    return NotFound();
                }

                try
                {
                    var TimeSheetMP = new TimeSheetModal
                    {
                        Username = model.Username,
                        DateSubmit = model.PunchIn,
                        TimeSheet_Department = User.FindFirst(ClaimTypes.GroupSid).Value,
                        TimeSheet_Reference = "TS" + model.PunchIn.Value.ToString("yyyyMMdd") + "MP",
                        TimeSheet_Start = model.PunchIn,
                        TimeSheet_End = model.PunchOut,
                        TimeSheet_Break_Start = model.LunchIn,
                        TimeSheet_Break_End = model.LunchOut,
                    };
                    newForm = await _formRepo.AddFormAsync(TimeSheetMP);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpPost("deleteTimeSheet/deleteTimeSheetRejectOff")] ////check
        [Authorize]
        public async Task<IActionResult> DeleteFormOff(TimeOffFormModal model)
        {
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var filterByUser = TimeSheet_All.Where(ts => ts.Username == model.Username).ToList();
            try
            {
                if (model.TimeOffStart != model.TimeOffEnd)
                {
                    int numDays = (model.TimeOffEnd.Value - model.TimeOffStart.Value).Days + 1;
                    DateTime[] dates = new DateTime[numDays];
                    for (int i = 0; i < numDays; i++)
                    {
                        dates[i] = model.TimeOffStart.Value.AddDays(i);
                    }
                    var filterByDate = filterByUser.Where(ts => (dates).Contains(ts.DateSubmit.Value)).ToList();
                    var filterByOFF = filterByDate.Where(ts => ts.TimeSheet_Reference.Contains("OFF")).ToList();
                    foreach (var item in filterByOFF)
                    {
                        await _formRepo.DeleteFormAsync(item.ID);
                    }
                }
                else
                {
                    DateTime date = model.TimeOffStart.Value;
                    var filterByDate = filterByUser.Where(ts => date == ts.DateSubmit.Value).ToList();

                    foreach (var item in filterByDate)
                    {
                        await _formRepo.DeleteFormAsync(item.ID);
                    }
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("deleteTimeSheet/deleteTimeSheetRejectMissPunch")] ////check
        [Authorize]
        public async Task<IActionResult> DeleteFormMissPunch(MissPunchFormModal model)
        {
            var TimeSheet_All = await _formRepo.getAllFormsAsync();
            var filterByUser = TimeSheet_All.Where(ts => ts.Username == model.Username).ToList();
            try
            {
                var filterByDate = filterByUser.Where(ts => model.PunchIn.Value.ToString("yyyyMMdd") == ts.DateSubmit.Value.ToString("yyyyMMdd")).ToList();
                var filterByMissPunch = filterByDate.Where(ts => ts.TimeSheet_Reference.Contains("MP")).ToList();
                foreach (var item in filterByMissPunch)
                {
                    await _formRepo.DeleteFormAsync(item.ID);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("updateTimeSheetByPunch")]////check
        [Authorize]
        public async Task<IActionResult> UpdateFormByPunch(TimeSheetModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                if (UserNameClaim != null)
                {
                    DateTime? Datesubmit = new DateTime();
                    if (model.TimeSheet_Start != null) Datesubmit = model.TimeSheet_Start;
                    if (model.TimeSheet_Break_Start != null) Datesubmit = model.TimeSheet_Break_Start;
                    if (model.TimeSheet_Break_End != null) Datesubmit = model.TimeSheet_Break_End;
                    if (model.TimeSheet_End != null) Datesubmit = model.TimeSheet_End;

                    var TimeSheetList = await _formRepo.getAllFormsAsync();
                    var TimeSheetList_Today = TimeSheetList.FirstOrDefault(ts => ts.Username == UserNameClaim &&
                                                                            ts.TimeSheet_Reference == ("TS" + Datesubmit.Value.ToString("yyyyMMdd")));


                    if (TimeSheetList_Today == null)
                    { return NotFound(); }
                    else
                    {
                        if (model.TimeSheet_Start != null) TimeSheetList_Today.TimeSheet_Start = model.TimeSheet_Start;
                        if (model.TimeSheet_Break_Start != null) TimeSheetList_Today.TimeSheet_Break_Start = model.TimeSheet_Break_Start;
                        if (model.TimeSheet_Break_End != null) TimeSheetList_Today.TimeSheet_Break_End = model.TimeSheet_Break_End;
                        if (model.TimeSheet_End != null) TimeSheetList_Today.TimeSheet_End = model.TimeSheet_End;
                        var result = await _formRepo.UpdateFormAsync(TimeSheetList_Today);
                        return Ok(result);
                    }
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("ediTimeSheet/{ID}")]////check
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


        [HttpDelete("deleteTimeSheet/{ID}")]////check
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

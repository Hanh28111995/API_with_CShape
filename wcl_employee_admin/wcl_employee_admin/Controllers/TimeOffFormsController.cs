using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories.TimeOffRepository;
using System.Threading;
using wcl_employee_admin.Data;

namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeOffFormsController : ControllerBase
    {
        private readonly ITimeOffFormRepository _formRepo;

        public TimeOffFormsController(ITimeOffFormRepository repo)
        {
            _formRepo = repo;
        }

        [HttpGet("getCalendarEvent")]
        [Authorize]
        public async Task<IActionResult> GetCalendarEvent()
        {
            try
            {
                var TimeOffList = await _formRepo.getAllFormsAsync();
                var TimeOffList_accept = TimeOffList.Where(form => form.HRStatus == true).ToList();
                List<CalendarEvent> EvenList = new List<CalendarEvent>();

                for (int i = 0; i < TimeOffList_accept.Count; i++)
                {
                    if (TimeOffList_accept[i].TimeOffStart != TimeOffList_accept[i].TimeOffEnd)
                    {
                        int numDays = (TimeOffList_accept[i].TimeOffEnd.Value - TimeOffList_accept[i].TimeOffStart.Value).Days + 1;
                        DateTime[] dates = new DateTime[numDays];
                        for (int y = 0; y < numDays; y++)
                        {
                            dates[y] = TimeOffList_accept[i].TimeOffStart.Value.AddDays(y);
                            var Event = new CalendarEvent
                            {
                                Username = TimeOffList_accept[i].Username,
                                Department = TimeOffList_accept[i].Department,
                                ShiftDay = TimeOffList_accept[i].ShiftDay,
                                TimeOff = dates[y],
                            };
                            EvenList.Add(Event);
                        }
                    }
                    else
                    {
                        var Event = new CalendarEvent
                        {
                            Username = TimeOffList_accept[i].Username,
                            Department = TimeOffList_accept[i].Department,
                            ShiftDay = TimeOffList_accept[i].ShiftDay,
                            TimeOff = TimeOffList_accept[i].TimeOffStart,
                        };
                        EvenList.Add(Event);
                    }
                }
                var groupEvent = EvenList.GroupBy(x => x.TimeOff);
                return Ok(groupEvent.Select(evt => new
                {
                    day = evt.Key,
                    user = evt.ToList()
                }));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getTimeOffForm/All")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]

        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                return Ok(await _formRepo.getAllFormsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getTimeOffForm/CoWorker")]
        [Authorize]
        public async Task<IActionResult> GetAllCoWorkerForms()
        {
            try
            {
                var UserMailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
                var TimeOffAll = await _formRepo.getAllFormsAsync();
                var CoWorkerForms = TimeOffAll.Where(model => model.CoverWorker == UserMailClaim).ToList(); 
                return Ok(CoWorkerForms);
            }
            catch
            {
                return BadRequest();
            }
        }

      

        [HttpGet("getTimeOffForm/Manager")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]

        public async Task<IActionResult> GetGroupForms()
        {
            try
            {
                var group = User.FindFirst(ClaimTypes.GroupSid)?.Value;
                return Ok(await _formRepo.getGroupFormsAsync(group));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("getTimeOffForm/user")]
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

        [HttpGet("getTimeOffForm/{ID}")]
        [Authorize]
        public async Task<IActionResult> GetFormbyId(int ID)
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


        [HttpPost("addTimeOffForm")]
        [Authorize]
        public async Task<IActionResult> AddNewForm(TimeOffFormModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                model.Reference = "TO" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                model.DateSubmit = DateTime.Now;

                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("editTimeOffForm/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR, Manager")]
        public async Task<IActionResult> UpdateForm(TimeOffFormModal model)
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

        [HttpDelete("deleteTimeOffForm/{ID}")]
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

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
            //_formTimeOffRepo = formTimeOffRepo;
        }

        [HttpGet("getTimeSheet/All")]
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


        [HttpPost("addTimeSheet")]
        [Authorize]
        public async Task<IActionResult> AddNewForm(TimeSheetModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                model.TimeSheet_Reference = "TS" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                model.DateSubmit = DateTime.Now;
                var Timeoff_All = await _formTimeOffRepo.getAllFormsAsync();
                var filterByUser = Timeoff_All.Where(dayoff => dayoff.Username == model.Username).ToList();
                var filterByDate = filterByUser.Where(p => (DateTime.Compare(p.TimeOffStart, model.DateSubmit ) <= 0)&&(DateTime.Compare( model.DateSubmit, p.TimeOffEnd) >= 0)).ToList();



                //var filterByTime = filterByUser.Where(dayoff => dayoff. == model.DateSubmit).ToList();

                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("editTimeSheet/{ReferenceID}")]
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

        [HttpDelete("deleteVTOForm/{ID}")]
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

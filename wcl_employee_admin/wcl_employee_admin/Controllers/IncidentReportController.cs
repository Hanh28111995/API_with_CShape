using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories;


namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportController : ControllerBase
    {
        private readonly IIncidentReportFormRepository _formRepo;

        public IncidentReportController(IIncidentReportFormRepository repo)
        {
            _formRepo = repo;
        }

        [HttpGet("getIncidentReportForm/All")]
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

        [HttpGet("getIncidentReportForm/user")]
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

        [HttpGet("getIncidentReportForm/{Reference}")]
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


        [HttpPost("addIncidentReportForm")]
        [Authorize]
        public async Task<IActionResult> AddNewForm(IncidentReportFormModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                model.Reference = "IR" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                model.SubmitDate = DateTime.Now.ToString("MM/dd/yyyy");

                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("editIncidentReportForm/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> UpdateForm(IncidentReportFormModal model)
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

        [HttpDelete("deleteIncidentReportForm/{ReferenceID}")]
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

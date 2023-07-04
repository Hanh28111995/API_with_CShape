using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories.VTOformRepository;

namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VTOFormsController : ControllerBase
    {
        private readonly IVTOFormRepository _formRepo;

        public VTOFormsController(IVTOFormRepository repo)
        {
            _formRepo = repo;
        }

        [HttpGet("getVTOForm/All")]
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

        [HttpGet("getVTOForm/Manager")]
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


        [HttpGet("getVTOForm/user")]
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

        [HttpGet("getVTOForm/{Reference}")]
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


        [HttpPost("addVTOForm")]
        [Authorize]
        public async Task<IActionResult> AddNewForm(VTO_FormModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                model.Reference = "VTO" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
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

        [HttpPut("editVTOForm/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR, Manager")]
        public async Task<IActionResult> UpdateForm(VTO_FormModal model)
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

        [HttpDelete("deleteVTOForm/{ReferenceID}")]
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories;

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

        [HttpGet("getTimeOffForm/All")]
        //[Authorize]
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
        [HttpGet("getTimeOffForm/{Reference}")]
        //[Authorize]
        public async Task<IActionResult> GetFormbyId(int ReferenceID)
        {
            try
            {
                var Forms = await _formRepo.getFormAsync(ReferenceID);
                return Forms == null ? NotFound() : Ok(Forms);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("addTimeOffForm")]
        //[Authorize]
        public async Task<IActionResult> AddNewForm(TimeOffFormModal model)
        {
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return Ok();
            }
        }

        [HttpPut("editTimeOffForm/{ReferenceID}")]
        //[Authorize]
        public async Task<IActionResult> UpdateBook(int ReferenceID, TimeOffFormModal model)
        {
            try 
            { 
            if (ReferenceID != model.ReferenceID)
            {
                return NotFound();
            }
            await _formRepo.UpdateFormAsync(ReferenceID, model);
            return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteTimeOffForm/{ReferenceID}")]
        //[Authorize]
        public async Task<IActionResult> DeleteForm([FromRoute] int ReferenceID)
        {
            try 
            { 
            await _formRepo.DeleteFormAsync(ReferenceID);
            return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

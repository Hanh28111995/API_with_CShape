﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class MissPunchFormsController : ControllerBase
    {
        private readonly IMissPunchFormRepository _formRepo;

        public MissPunchFormsController(IMissPunchFormRepository repo)
        {
            _formRepo = repo;
        }

        [HttpGet("getMissPunchForm/All")]
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

        [HttpGet("getMissPunchForm/user")]
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

        [HttpGet("getMissPunchForm/{Reference}")]
        [Authorize]
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


        [HttpPost("addMissPunchForm")]
        [Authorize]
        public async Task<IActionResult> AddNewForm(MissPunchFormModal model)
        { 
            try
            {
                var UserNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                model.Username = UserNameClaim ?? "";
                model.Reference = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");

                var newForm = await _formRepo.AddFormAsync(model);
                var form = await _formRepo.getFormAsync(newForm);
                return form == null ? NotFound() : Ok(form);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("editMissPunchForm/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> UpdateBook(int ReferenceID, MissPunchFormModal model)
        {
            try 
            { 
            if (ReferenceID != model.ID)
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

        [HttpDelete("deleteMissPunchForm/{ReferenceID}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
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

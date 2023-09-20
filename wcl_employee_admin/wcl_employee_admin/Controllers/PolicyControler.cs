using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using wcl_employee_admin.Data;
using System.Configuration;

namespace wcl_employee_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyControler : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration configuration;

        public PolicyControler(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {        
            _hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }


        [HttpGet("getPolicyAllFile")]

        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                string DirectURL = Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles");
                string[] files = Directory.GetFiles(DirectURL);

                return Ok(files.Select(item => new
                {
                    name = item.Replace(DirectURL+ "\\", "").Split('.')[0],
                    url = baseURL + "/PolicyFiles/" + item.Replace(DirectURL+ "\\", ""),
                }));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("addPolicyFile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async  Task<IActionResult> AddNewForm(IFormFile model)
        {

            try
            {
                if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles", model.FileName)))
                {
                    //Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles", model.FileName));
                    FileUpload.FileUpload.SingleFileCurrentProject(model, _hostingEnvironment.WebRootPath, Path.Combine("PolicyFiles",""), model.FileName);                   
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}

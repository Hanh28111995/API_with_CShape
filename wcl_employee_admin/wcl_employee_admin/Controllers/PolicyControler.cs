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

        public async Task<IActionResult> GetAllFiles()
        {
            try
            {
                string baseURL = configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
                string DirectURL = Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles");
                string[] files = Directory.GetFiles(DirectURL);

                return Ok(files.Select(item => new
                {
                    name = item.Replace(DirectURL + "\\", ""),
                    url = baseURL + "/PolicyFiles/" + item.Replace(DirectURL + "\\", ""),
                }));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("addPolicyFile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> AddNewFile(IFormFile PolicyFile)
        {

            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles", PolicyFile.FileName);
                if (!System.IO.File.Exists(path))
                {
                    FileUpload.FileUpload.SingleFileCurrentProject(PolicyFile, _hostingEnvironment.WebRootPath, Path.Combine("PolicyFiles", ""), PolicyFile.FileName);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("deletePolicyFile/{FileName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "HR")]
        public async Task<IActionResult> DeleteFile([FromRoute] string FileName)
        {
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles", FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "PolicyFiles", FileName));        
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

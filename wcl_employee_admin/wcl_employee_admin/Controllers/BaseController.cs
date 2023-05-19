using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace wcl_employee_admin.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userId)) return "";
            return userId;
        }

    }
}

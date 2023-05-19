using Microsoft.Build.Framework;

namespace wcl_employee_admin.Models
{
    public class PhotoDetail
    {
        [Required]
        public IFormFileCollection Files { set; get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class DisableAccModel
    {
        [Required]
        public string Username { get; set; }
    }
}

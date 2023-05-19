using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set;} 
        
    }
}

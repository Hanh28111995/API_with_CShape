using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class ChangePassModel
    {
        //[Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}

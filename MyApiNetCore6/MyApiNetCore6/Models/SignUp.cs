using System.ComponentModel.DataAnnotations;

namespace MyApiNetCore6.Models
{
    public class SignUp
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string PassWord { get; set; } = null!;
        [Required]
        public string ConfirmPassWord { get; set; } = null!;
    }
}

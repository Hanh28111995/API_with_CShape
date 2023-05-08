using System.ComponentModel.DataAnnotations;

namespace MyApiNetCore6.Models
{
    public class SignIn
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string PassWord { get; set; } = null!;
    }
}

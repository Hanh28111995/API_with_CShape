using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace wcl_employee_admin.Data;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FullName { get; set; } 

    public string Phone { get; set; }
    public string PhotoUrl { get; set; } 
    public string ZIPCode { get; set; } 
    public string EEO { get; set; } 

    public string Position { get; set; }
    public string Gender { get; set; } 
    public string ConfirmNumber { get; set; }
    public string CardNumber { get; set; } 
    public int netSalary { get; set; } = 0!;
    public int grossSalary { get; set; } = 0!;

    public string Note { get; set; } 
    public string NickName { get; set; } 

    //public string Email { get; set; } = null!;
    public string Address { get; set; } 
    public string Location { get; set; } 

    public string Department { get; set; } 
    public string ContractType { get; set; } 
    public string BirthDay { get; set; } 
    public string Marital { get; set; } 
    public string DateStart { get; set; }

    public string Passport { get; set; } 

    //public string Password { get; set; } = "wcl";

}


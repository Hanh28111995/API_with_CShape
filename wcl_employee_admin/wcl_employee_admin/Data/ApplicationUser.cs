using Microsoft.AspNetCore.Identity;

namespace wcl_employee_admin.Data;

public class ApplicationUser : IdentityUser
{



    //public string UserName { get; set; }
    public string Photourl { get; set; }
    public string Fullname { get; set; }
    public string Passport { get; set; }
    public string Nickname { get; set; }
    public string Eeo { get; set; }
    public string Location { get; set; }
    public string Department { get; set; }
    public string Contracttype { get; set; }
    public string Marital { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Zipcode { get; set; }
    public string Position { get; set; }
    public string Status { get; set; }
    public string Departmentroles { get; set; }
    public string Gender { get; set; }
    public string Confirmnumber { get; set; }

    public DateTime? Birthday { get; set; }
    public string Cardnumber { get; set; }
    public DateTime? Datestart { get; set; }
    public string Sha { get; set; }
    public string Vha { get; set; }
    public string Dkp { get; set; }
    public int? Netsalary { get; set; } = 0;
    public int? Grosssalary { get; set; } = 0;
    public DateTime? Datecreated { get; set; }
    public string Note { get; set; }
    public string Password { get; set; }

}
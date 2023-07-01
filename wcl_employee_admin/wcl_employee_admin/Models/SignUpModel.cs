using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class SignUpModel
    {
        public string UserName { get; set; }
        public IFormFile Photos { set; get; }

        public string Fullname { get; set; } 

        public string Phone { get; set; } 

        public string Zipcode { get; set; } 
        public string Eeo { get; set; } 
        public string Position { get; set; } 
        public string Gender { get; set; } 
        public string Confirmnumber { get; set; } 
        public string Cardnumber { get; set; } 
        public int? Netsalary { get; set; } = 0;
        public int? Grosssalary { get; set; } = 0;
        public string Status { get; set; }
        public string Note { get; set; } 
        public string Nickname { get; set; } 

        public string Email { get; set; } 
        public string Address { get; set; } 
        public string Location { get; set; } 

        public string Department { get; set; }
        public string Contracttype { get; set; } 
        public string Birthday { get; set; } 
        public string Marital { get; set; } 
        public string Datestart { get; set; } 

        public string Passport { get; set; } 

        public string Password { get; set; } 

    }
}

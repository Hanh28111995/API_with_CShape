using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class MissPunchFormModal
    {
        [Key]
        public int ReferenceID { get; set; }

        public string Username { get; set; }
        
        public string Location { get; set; }
        
        public string PunchIn { get; set; }
        
        public string PunchOut { get; set; }
        
        public string LunchIn { get; set; }
        
        public string LunchOut { get; set; }
        
        public string Manager { get; set; }
        
        public string Reason { get; set; }
        
        public bool? ManagerStatus { get; set; }
        public bool? HRStatus { get; set; }
    }
}

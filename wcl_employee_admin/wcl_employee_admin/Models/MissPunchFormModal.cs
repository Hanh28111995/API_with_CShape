using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class MissPunchFormModal
    {
        [Key]
        public int ReferenceID { get; set; }

        public string Username { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PunchIn { get; set; }
        [Required]
        public string PunchOut { get; set; }
        [Required]
        public string LunchIn { get; set; }
        [Required]
        public string LunchOut { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public string Reason { get; set; }
        
        public bool? ManagerStatus { get; set; }
        public bool? HRStatus { get; set; }
    }
}

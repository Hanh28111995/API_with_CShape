using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class VTO_FormModal
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public DateTime? DateSubmit { get; set; }
        public string Manager { get; set; }
        public DateTime? ManagerDate { get; set; }
        public bool? ManagerStatus { get; set; }
        public DateTime? HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Request { get; set; }
        public string Note { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Miss Punch Forms")]
    public class MissPunchForm
    {
        [Key]
        public int ID { get; set; }

        public string Reference { get; set; }

        public string Username { get; set; }
        
        public string Location { get; set; }
        
        public DateTime? PunchIn { get; set; }
        
        public DateTime? PunchOut { get; set; }
        
        public DateTime? LunchIn { get; set; }
        
        public DateTime? LunchOut { get; set; }
        
        public string Manager { get; set; }
        
        public string Reason { get; set; }

        public DateTime? DateSubmit { get; set; }

        public bool? ManagerStatus { get; set; }

        public DateTime? ManagerDate { get; set; }

        public bool? HRStatus { get; set; }

        public DateTime? HrDate { get; set; }

        public string Note { get; set; }

    }
}


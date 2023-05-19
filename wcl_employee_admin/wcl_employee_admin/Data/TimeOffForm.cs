using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Time Off Forms")]
    public class TimeOffForm
    {
        [Key]
        public int ReferenceID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string TimeOffStart { get; set; }
        [Required]
        public string TimeOffEnd { get; set; }
        [Required]
        public string CoverWorker { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public string PayTime { get; set; }
        [Required]
        public string ShiftDay { get; set; }
        [Required]
        public string Reason { get; set; }

        public bool? ManagerStatus   { get; set; } 
        public bool? CoworkerStatus { get; set; }
        public bool? HRStatus { get; set; }

    }
}


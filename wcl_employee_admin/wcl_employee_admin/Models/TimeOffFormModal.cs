using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class TimeOffFormModal
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
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

        public string SubmitDate { get; set; }
        public string ManagerDate { get; set; }

        public bool? ManagerStatus { get; set; }

        public bool CoworkerDate { get; set; }

        public bool? CoworkerStatus { get; set; }

        public string HrDate { get; set; }

        public bool? HRStatus { get; set; }
    }
}

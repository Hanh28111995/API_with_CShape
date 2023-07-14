using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class TimeOffFormModal
    {
        [Key]
        public int ID { get; set; }

        public string Reference { get; set; }
        public string Username { get; set; }

        public string Location { get; set; }

        public DateTime TimeOffStart { get; set; }

        public DateTime TimeOffEnd { get; set; }

        public string CoverWorker { get; set; }

        public string Manager { get; set; }

        public string PayTime { get; set; }

        public string ShiftDay { get; set; }

        public string Reason { get; set; }

        public DateTime DateSubmit { get; set; }

        public DateTime ManagerDate { get; set; }

        public bool? ManagerStatus { get; set; }

        public DateTime CoworkerDate { get; set; }

        public bool? CoworkerStatus { get; set; }

        public DateTime HrDate { get; set; }

        public bool? HRStatus { get; set; }
        public string Note { get; set; }
    }
}

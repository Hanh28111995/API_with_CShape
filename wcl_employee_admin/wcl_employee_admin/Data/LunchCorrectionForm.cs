using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Lunch Correction Forms")]
    public class LunchCorrectionForm
    {

        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Manager { get; set; }
        public bool? LunchCorrectionForgot { get; set; }
        public DateTime? LunchCorrection_start { get; set; }
        public DateTime? LunchCorrection_end { get; set; }
        public string Reason { get; set; }
        public DateTime? LunchCorrection_date_overtime { get; set; }
        public string Reason_Options { get; set; }
        public string Other_Reason { get; set; }
        public DateTime? DateSubmit { get; set; }
        public bool? ManagerStatus { get; set; }
        public DateTime? ManagerDate { get; set; }
        public bool? HRStatus { get; set; }
        public DateTime? HrDate { get; set; }
    }
}


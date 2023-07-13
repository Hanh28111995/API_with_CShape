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

        public bool? lunchCorrectionForgot { get; set; }
        public string lunchCorrection_start { get; set; }
        public string lunchCorrection_end { get; set; }
        public string reason { get; set; }



        public string reason_Options { get; set; }
        public string other_Reason { get; set; }



        public string ManagerDate { get; set; }
        public bool? ManagerStatus { get; set; }
        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }

    }
}


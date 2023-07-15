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

        public string Nickname { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfAccident { get; set; }

        public string ReasonOccur { get; set; }

        public string OtherInvolved { get; set; }

        public string CauseBy { get; set; }

        public string OtherIncident { get; set; }

        public string DesOfInjury { get; set; }

        public string NatureOfInjury { get; set; }

        public string OtherInjury { get; set; }
        public string BodyAffected_Right { get; set; }
        public string BodyAffected_Left { get; set; }
        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Insurance { get; set; }
        public string AccountNo { get; set; }
        public string CareProvided { get; set; }
        public DateTime? DateSubmit { get; set; }
        public DateTime? HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }

    }
}


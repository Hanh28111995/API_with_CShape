using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class InjuryReportFormModal
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }

        /// ////////////////////////////////

        public string Fullname { get; set; }

        public string Nickname { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        /// ////////////////////////////////

        public string DateOfAccident { get; set; }

        public string ReasonOccur { get; set; }

        public string OtherInvolved { get; set; }

        public string CauseBy { get; set; }

        public string OtherIncident { get; set; }

        /// ////////////////////////////////

        public string DesOfInjury { get; set; }

        public string NatureOfInjury { get; set; }

        public string OtherInjury { get; set; }

        /// //////////////////////////////// <body-affected>
        public string BodyAffected_Right { get; set; }
        public string BodyAffected_Left { get; set; }

        /// //////////////////////////////// <Care>

        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Insurance { get; set; }
        public string AccountNo { get; set; }
        public string CareProvided { get; set; }

        
        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }
    }
}

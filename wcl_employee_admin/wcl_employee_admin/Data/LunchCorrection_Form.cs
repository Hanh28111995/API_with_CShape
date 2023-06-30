using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Lunch Correction Forms")]
    public class LunchCorrection_Form
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Manager { get; set; }

        public bool A_Option { get; set; }
        public bool A_Option_1 { get; set; }
        public string A_Option_LunchIn { get; set; }
        public string A_Option_LunchOut { get; set; }
        public string A_Option_Reason { get; set; }



        public bool B_Option { get; set; }
        public bool B_Option_1 { get; set; }
        public bool B_Option_2 { get; set; }
        public bool B_Option_3 { get; set; }
        public bool B_Option_4 { get; set; }
        public bool B_Option_5 { get; set; }
        public string B_Option_other_reason { get; set; }



        public string Location { get; set; }
        public string DateRequest { get; set; }



        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }

    }
}


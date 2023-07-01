using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("VTO Forms")]
    public class VTO_Form
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string DateRequest { get; set; }
        public string Manager { get; set; }
        public bool? ManagerStatus { get; set; }
        public string ManagerDate { get; set; }
        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }

    }
}


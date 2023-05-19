using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Miss Punch Forms")]
    public class MissPunchForm
    {
        [Key]
        public int ReferenceID { get; set; }

        public string Username { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public string PunchIn { get; set; }
        [Required]
        public string PunchOut { get; set; }
        [Required]
        public string LunchIn { get; set; }
        [Required]
        public string LunchOut { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public string Reason { get; set; }

        public bool? ManagerStatus { get; set; }
        public bool? HRStatus { get; set; }

    }
}


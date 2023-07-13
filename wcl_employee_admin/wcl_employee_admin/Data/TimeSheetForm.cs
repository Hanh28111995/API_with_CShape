using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("TimeSheet Forms")]
    public class TimeSheetForm
    {
        [Key]
        public int ID { get; set; }
        public string TimeSheet_Reference { get; set; }
        public string Username { get; set; }
        public string DateSubmit { get; set; }

        public string TimeSheet_Start { get; set; }
        public string TimeSheet_End { get; set; }
        public string TimeSheet_Break_Start { get; set; }
        public string TimeSheet_Break_End { get; set; }
        public string TimeSheet_Department { get; set; }
        public string TimeSheet_TimeOff_Vacation { get; set; }
        public string TimeSheet_TimeOff_Holiday { get; set; }
        public string TimeSheet_TimeOff_45Day { get; set; }
        public string TimeSheet_TimeOff_noWork { get; set; }
        public string TimeSheet_TimeOff_note { get; set; }

    }
}


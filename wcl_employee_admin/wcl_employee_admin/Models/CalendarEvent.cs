using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class CalendarEvent
    {
        public string Username { get; set; }
        public string Department { get; set; }
        public DateTime? TimeOff { get; set; }
        public string ShiftDay { get; set; }      
    }
}

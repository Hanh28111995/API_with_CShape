using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("EmpStartingInfo Forms")]
    public class EmpStartingInfoForm
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public DateTime? Datestart { get; set; }
        public string Owner { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhone { get; set; }
        public string ManagerEmail { get; set; }
        public string SupervisorName { get; set; }
        public string WhoTraining { get; set; }
        public string WorkingHour { get; set; }
        public string Position { get; set; }
        public string PartTimeOrFullTime { get; set; }
        public string WorkingAddress { get; set; }
        public string TeamMembers { get; set; }
        public string Department { get; set; }
        public DateTime? DateWithNeed { get; set; }
        public DateTime? DateSend { get; set; }
        public string ForOffice { get; set; }
        public string ForWareHouse { get; set; }
        public string ForManager { get; set; }
        public string UserRequest { get; set; }
        public string Note { get; set; }
        public bool? SendITStatus { get; set; }
        public bool? ITfeedbackStatus { get; set; }

    }
}


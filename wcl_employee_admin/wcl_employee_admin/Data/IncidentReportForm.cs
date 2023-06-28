using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("IncidentReport Forms")]
    public class IncidentReportForm
    {
        [Key]

        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string DateOfIncident { get; set; }
        public string Witness { get; set; }
        public string Manager { get; set; }
        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Reason { get; set; }

    }
}


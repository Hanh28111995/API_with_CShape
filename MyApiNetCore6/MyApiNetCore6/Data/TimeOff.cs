using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiNetCore6.Data
{
    [Table("TimeOff")]
    public class TimeOff
    {
        [Key]
        public string Reference { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string TimeOffStart { get; set; }
        [Required]
        public string TimeOffEnd { get; set; }
        [Required]
        public string CoverWorker { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public string PayTime { get; set; }
        [Required]
        public string ShiftDay { get; set; }
        [Required]
        public string Reason { get; set; }

        public bool ManagerStatus { get; set; }
        public bool CoworkerStatus { get; set; }
        public bool HRStatus { get; set; }

    }
}


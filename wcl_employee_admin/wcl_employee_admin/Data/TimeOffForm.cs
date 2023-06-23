﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Time Off Forms")]
    public class TimeOffForm
    {
        [Key]
        public int ID { get; set; }

        public string Reference { get; set; }
        
        public string Location { get; set; }
        
        public string TimeOffStart { get; set; }
        
        public string TimeOffEnd { get; set; }
        
        public string CoverWorker { get; set; }
        
        public string Manager { get; set; }
        
        public string PayTime { get; set; }
        
        public string ShiftDay { get; set; }
        
        public string Reason { get; set; }

        public string SubmitDate { get; set; }

        public string ManagerDate { get; set; }

        public bool? ManagerStatus   { get; set; }

        public bool CoworkerDate { get; set; }

        public bool? CoworkerStatus { get; set; }

        public string HrDate { get; set; }

        public bool? HRStatus { get; set; }

    }
}


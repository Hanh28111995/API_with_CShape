﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wcl_employee_admin.Data
{
    [Table("Miss Punch Forms")]
    public class MissPunchForm
    {
        [Key]
        public int ID { get; set; }

        public string Reference { get; set; }

        public string Username { get; set; }
        
        public string Location { get; set; }
        
        public string PunchIn { get; set; }
        
        public string PunchOut { get; set; }
        
        public string LunchIn { get; set; }
        
        public string LunchOut { get; set; }
        
        public string Manager { get; set; }
        
        public string Reason { get; set; }

        public string SubmitDate { get; set; }

        public bool? ManagerStatus { get; set; }

        public string ManagerDate { get; set; }

        public bool? HRStatus { get; set; }

        public string HrDate { get; set; }

    }
}


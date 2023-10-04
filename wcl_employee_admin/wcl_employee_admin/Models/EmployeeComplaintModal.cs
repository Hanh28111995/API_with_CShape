using System;
using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class EmployeeComplaintModal
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Department { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateSubmit { get; set; }
        public DateTime? DateComplaint { get; set; }
        public string Manager { get; set; }
        public string DescribeWitness { get; set; }
        public string DescribeDetail { get; set; }
        public string DescribeSolution { get; set; }
        public string DescribeComment { get; set; }


        public DateTime? ManagerDate { get; set; }
        public bool? ManagerStatus { get; set; }
        public DateTime? HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }
    }
}

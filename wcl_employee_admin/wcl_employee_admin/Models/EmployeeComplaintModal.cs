using System.ComponentModel.DataAnnotations;

namespace wcl_employee_admin.Models
{
    public class EmployeeComplaintModal
    {
        [Key]
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }

        public string DateSubmit { get; set; }
        public string Manager { get; set; }
        public string DescribeWitness { get; set; }
        public string DescribeDetail { get; set; }
        public string DescribeSolution { get; set; }
        public string DescribeComment { get; set; }


        public string ManagerDate { get; set; }
        public bool? ManagerStatus { get; set; }
        public string SubmitDate { get; set; }
        public string HrDate { get; set; }
        public bool? HRStatus { get; set; }
        public string Note { get; set; }
    }
}

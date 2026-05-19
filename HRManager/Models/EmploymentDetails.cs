using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class EmploymentDetails
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoiningDate { get; set; }
        public string ActivityStatus { get; set; } // Active/Inactive/On Leave/Suspended
        public string Department { get; set; }
        public string JoinDesignation { get; set; }
        public string EmployeeStatus { get; set; } // Permanent/Contract
        public string BranchName { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
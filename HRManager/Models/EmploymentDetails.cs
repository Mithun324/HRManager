using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class EmploymentDetails
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string? Department { get; set; }
        public string? ActivityStatus { get; set; }

        // --- ADD THESE MISSING PROPERTIES ---
        public string? Designation { get; set; }
        public string? Shift { get; set; }
        public DateTime? JoiningDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public string? JoinDesignation { get; set; } // Error in Create.cshtml
        public string? EmployeeStatus { get; set; }
        public string? BranchName { get; set; }

    }
}
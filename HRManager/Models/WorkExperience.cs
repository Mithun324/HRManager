using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class WorkExperience
    {
        [Key]
        public int ExperienceId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? EmployerLocation { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? LengthOfService { get; set; }
        public string? ReasonForLeaving { get; set; }
        public string? Achievements { get; set; }
        public string? Responsibilities { get; set; }

        public int WorkExperienceId { get; set; }
        public string? PreviousEmployerName { get; set; }
        public string? PreviousEmployerLocation { get; set; }
        public string? PreviousEmployerWebsite { get; set; }
        public string? PreviousDesignation { get; set; }
   
        public DateTime? EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public string? Department { get; set; }
        
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class TrainingInformation
    {
        [Key]
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? TrainingTitle { get; set; }
        public string? TrainingType { get; set; } // Internal / External / Workshop etc.
        public string? OrganizedBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public string? TrainingLocation { get; set; }
        public string? TrainingMode { get; set; } // Online / Offline / Hybrid
        public string? CertificationReceived { get; set; } // Yes / No
        public string? CertificateNumber { get; set; }
        public string? CertificateFileUrl { get; set; }
        public string? TrainingName { get; set; }
    }
}
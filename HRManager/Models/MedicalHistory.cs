using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedicalRecordId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? ConditionName { get; set; }
        public string? Status { get; set; } // Ongoing / Treated / Recovered
        public string? TreatmentDetails { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public string? Notes { get; set; }
    }
}
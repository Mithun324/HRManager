using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class ProfessionalQualification
    {
        [Key]
        public int QualificationId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? CertificationName { get; set; }
        public string? Subject { get; set; }
        public string? InstituteName { get; set; }
        public int? PassingYear { get; set; }
        public string? MarkGrade { get; set; }
        public string? Remarks { get; set; }
    }
}
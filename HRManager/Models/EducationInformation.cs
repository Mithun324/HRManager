using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class EducationInformation
    {
        [Key]
        public int EducationId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        // --- ADD THESE MISSING PROPERTIES ---
        public string? DegreeName { get; set; }
      
        public int? PassingYear { get; set; }

        public virtual Employee? Employee { get; set; }
        public string? InstitutionName { get; set; }
        public string? MajorGroup { get; set; }
        public string? Grade { get; set; }
        public string? Duration { get; set; }
    }
}
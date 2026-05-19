using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class SkillCompetency
    {
        [Key]
        public int SkillId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? SkillName { get; set; }
        public string? SkillType { get; set; } // Technical / Soft Skill
        public string? ProficiencyLevel { get; set; } // Beginner / Intermediate / Expert
        public string? ExperienceYears { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class LanguageSkill
    {
        [Key]
        public int LanguageSkillId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? LanguageName { get; set; }
        public string? SkillLevel { get; set; }
        public bool IsNative { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDuration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
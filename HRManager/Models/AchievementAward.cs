using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class AchievementAward
    {
        [Key]
        public int AchievementId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? AwardTitle { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfAchievement { get; set; }
        public string? IssuingAuthority { get; set; }
        public string? Level { get; set; } // National / Company / International
        public string? CertificateUrl { get; set; }
        public string? Remarks { get; set; }
    }
}
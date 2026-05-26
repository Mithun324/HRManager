using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class SocialMediaInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? PersonalWebsiteUrl { get; set; }
        public virtual Employee? Employee { get; set; }
        public string? PortfolioUrl { get; set; }
    }
}
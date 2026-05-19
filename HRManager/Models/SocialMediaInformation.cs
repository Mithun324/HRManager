using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class SocialMediaInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string LinkedInProfileURL { get; set; }
        public string FacebookProfileURL { get; set; }
        public string TwitterHandle { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramHandle { get; set; }
        public string InstagramURL { get; set; }
        public string GitHubProfileURL { get; set; }
        public string PersonalWebsiteURL { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
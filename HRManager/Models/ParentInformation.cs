using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class ParentInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }

        public string? FatherNID { get; set; }
        public string? FatherPassportNo { get; set; }
        public string? FatherMobile { get; set; }
        public string? MotherNID { get; set; }
        public string? MotherPassportNo { get; set; }
        public string? MotherMobile { get; set; }

        public virtual Employee? Employee { get; set; }

 
    }
}
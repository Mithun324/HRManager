using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class EmergencyContact
    {
        [Key]
        public int ContactId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? Name { get; set; }
        public string? Relation { get; set; }
        public string? Designation { get; set; }
        public string? Organization { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Occupation { get; set; }
        public string? OfficeAddress { get; set; }
        public string? HomeAddress { get; set; }
    }
}
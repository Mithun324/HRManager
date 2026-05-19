using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class TaxInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string? TaxZone { get; set; }
        public string? TaxCircle { get; set; }
        public virtual Employee? Employee { get; set; }

        public string? ETin { get; set; }
    }
}
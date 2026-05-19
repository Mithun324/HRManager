using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class ParentInformation
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string FathersName { get; set; }
        public string FathersNID { get; set; }
        public string FathersPassportNo { get; set; }
        public string FathersMobile { get; set; }

        public string MothersName { get; set; }
        public string MothersNID { get; set; }
        public string MothersPassportNo { get; set; }
        public string MothersMobile { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
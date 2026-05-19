using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class EmployeeInsurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? Name { get; set; }
        public string? Relation { get; set; }
        public string? Nid { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? InsuranceDate { get; set; }
    }
}
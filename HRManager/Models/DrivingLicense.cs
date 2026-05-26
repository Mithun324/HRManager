using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class DrivingLicense
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Category { get; set; }
        public string? PlaceOfIssue { get; set; }
        public DateTime? DateOfIssue { get; set; }
    
        public string? FileUrl { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
        public virtual Employee? Employee { get; set; }

        public DateTime? DateOfExpair { get; set; }
    }
}
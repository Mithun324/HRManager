using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class SpouseInformation
    {
        [Key]
        public int SpouseId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? BloodGroup { get; set; }
        public string? Nationality { get; set; }
        public string? Relationship { get; set; }
        public string? HighestEducation { get; set; }
        public string? HomeDistrict { get; set; }
        public string? ImageUrl { get; set; }
        public string? MarriageCertificateUrl { get; set; }
        public DateTime? DateOfMarriage { get; set; }

        public string? SpouseName { get; set; } 
        public string? NID { get; set; }      
        public string? Contact { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class ChildInformation
    {
        [Key]
        public int ChildId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? ChildName { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Education { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Relationship { get; set; }
        public string? PersonalEmail { get; set; }
        public string? NidBin { get; set; }
        public string? BloodGroup { get; set; }
        public string? ImageUrl { get; set; }
        public int ChildNo { get; set; }
    }
}
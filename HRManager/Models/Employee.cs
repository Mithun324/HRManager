using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace HRManager.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, StringLength(50)]
        public string EmployeeCode { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        public string NationalID { get; set; }
        public string PassportNo { get; set; }
        public string BirthIdentificationNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string BloodGroup { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string TINNo { get; set; }
        public string ImagePath { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        // Navigation Properties (1-to-1)
        public virtual ParentInformation ParentInformation { get; set; }
        public virtual SocialMediaInformation SocialMediaInformation { get; set; }
        public virtual EmploymentDetails EmploymentDetails { get; set; }
        public virtual AddressInformation AddressInformation { get; set; }
    }
}
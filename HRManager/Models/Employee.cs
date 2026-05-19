using System;
using System.Collections.Generic; // CRITICAL: Gives access to ICollection
using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, StringLength(50)]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string? FullName { get; set; }

        public string? NationalID { get; set; }
        public string? PassportNo { get; set; }
        public string? BirthIdentificationNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Religion { get; set; }
        public string? BloodGroup { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public string? TINNo { get; set; }
        public string? ImagePath { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        // ==========================================================================
        // One-to-One (1:1) Navigation Properties
        // ==========================================================================
        // Note: Changed to ParentsInformation to align with your separate file class names
        public virtual ParentInformation? ParentInformation { get; set; }
        public virtual SocialMediaInformation? SocialMediaInformation { get; set; }
        public virtual EmploymentDetails? EmploymentDetails { get; set; }
        public virtual DrivingLicense? DrivingLicense { get; set; }
        public virtual TaxInformation? TaxInformation { get; set; }

        // ==========================================================================
        // One-to-Many (1:N) Navigation Collections 
        // ==========================================================================
        // This explicitly creates the collection the repository is trying to load!
        public virtual ICollection<AddressInformation> Addresses { get; set; } = new List<AddressInformation>();
        public virtual ICollection<EducationInformation> Educations { get; set; } = new List<EducationInformation>();
        public virtual ICollection<TrainingInformation> Trainings { get; set; } = new List<TrainingInformation>();

        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public virtual ICollection<SkillCompetency> Skills { get; set; } = new List<SkillCompetency>();
        public virtual ICollection<SpouseInformation> Spouses { get; set; } = new List<SpouseInformation>();
        public virtual ICollection<ChildInformation> Children { get; set; } = new List<ChildInformation>();
        public virtual ICollection<BankingInformation> BankAccounts { get; set; } = new List<BankingInformation>();
        public virtual ICollection<AchievementAward> Achievements { get; set; } = new List<AchievementAward>();
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        public virtual ICollection<TravelHistory> TravelHistories { get; set; } = new List<TravelHistory>();
        public virtual ICollection<LoanHistory> LoanHistories { get; set; } = new List<LoanHistory>();
        public virtual ICollection<EmployeeInsurance> Insurances { get; set; } = new List<EmployeeInsurance>();
        public virtual ICollection<EmployeeHobby> Hobbies { get; set; } = new List<EmployeeHobby>();
        public virtual ICollection<LanguageSkill> LanguageSkills { get; set; } = new List<LanguageSkill>();
        public virtual ICollection<ExperienceLetter> ExperienceLetters { get; set; } = new List<ExperienceLetter>();
        public virtual ICollection<ProfessionalQualification> ProfessionalQualifications { get; set; } = new List<ProfessionalQualification>();
    }
}
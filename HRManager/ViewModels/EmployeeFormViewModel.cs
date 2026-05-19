using System.Collections.Generic;
using HRManager.Models;
using Microsoft.AspNetCore.Http; 

namespace HRManager.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; } = new Employee();
        public ParentInformation ParentInformation { get; set; } = new ParentInformation();
        public EmploymentDetails EmploymentDetails { get; set; } = new EmploymentDetails();
        public SocialMediaInformation SocialMediaInformation { get; set; } = new SocialMediaInformation();
        public DrivingLicense DrivingLicense { get; set; } = new DrivingLicense();
        public TaxInformation TaxInformation { get; set; } = new TaxInformation();

        public IFormFile? ProfilePhoto { get; set; }

        public List<AddressInformation> Addresses { get; set; } = new List<AddressInformation>();
        public List<EducationInformation> Educations { get; set; } = new List<EducationInformation>();
        public List<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public List<TravelHistory> TravelHistories { get; set; } = new List<TravelHistory>();
        public List<TrainingInformation> Trainings { get; set; } = new List<TrainingInformation>();
        public List<SpouseInformation> Spouses { get; set; } = new List<SpouseInformation>();
        public List<ProfessionalQualification> Qualifications { get; set; } = new List<ProfessionalQualification>();
        public List<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        public List<LoanHistory> LoanHistories { get; set; } = new List<LoanHistory>();
        public List<EmployeeInsurance> Insurances { get; set; } = new List<EmployeeInsurance>();
        public List<EmployeeHobby> Hobbies { get; set; } = new List<EmployeeHobby>();
        public List<ExperienceLetter> ExperienceLetters { get; set; } = new List<ExperienceLetter>();
        public List<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

        public List<LanguageSkill> Languages { get; set; } = new List<LanguageSkill>();
        public List<AchievementAward> Achievements { get; set; } = new List<AchievementAward>();
      
        public List<ChildInformation> Children { get; set; } = new List<ChildInformation>();

        public List<SkillCompetency> Skills { get; set; } = new List<SkillCompetency>();

        
        public List<BankingInformation> BankAccounts { get; set; } = new List<BankingInformation>();
    }
}
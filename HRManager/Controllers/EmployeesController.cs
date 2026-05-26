using HRManager.Data;
using HRManager.Models;
using HRManager.Repositories;
using HRManager.ViewModels;
using Microsoft.AspNetCore.Hosting; // Added for IWebHostEnvironment
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO; // Added for File handling
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly HRManagerDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Needed to get the wwwroot path

        // Injected Repository, DbContext, and WebHostEnvironment
        public EmployeeController(IEmployeeRepository employeeRepository, HRManagerDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // ==========================================================================
        // 1. INDEX LIST VIEW
        // ==========================================================================
        public async Task<IActionResult> Index(string? searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var employees = await _employeeRepository.GetAllEmployeesAsync(searchString);
            return View(employees);
        }

        // ==========================================================================
        // 2. DETAILS VIEW
        // ==========================================================================
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // ==========================================================================
        // 3. CREATE OPERATION (GET & POST)
        // ==========================================================================
        public IActionResult Create()
        {
            var viewModel = new EmployeeFormViewModel();

                // Exact type match instantiations to bypass reference faults
                Addresses = new List<AddressInformation> { new AddressInformation() },
                Educations = new List<EducationInformation> { new EducationInformation() },
                Trainings = new List<TrainingInformation> { new TrainingInformation() },
                EmergencyContact = new List<EmergencyContact> { new EmergencyContact() },
                WorkExperiences = new List<WorkExperience> { new WorkExperience() },
                Skills = new List<SkillCompetency> { new SkillCompetency() },
                Spouses = new List<SpouseInformation> { new SpouseInformation() },
                Children = new List<ChildInformation> { new ChildInformation() },
                BankAccounts = new List<BankingInformation> { new BankingInformation() },
                Achievements = new List<AchievementAward> { new AchievementAward() },
                MedicalHistories = new List<MedicalHistory> { new MedicalHistory() },
                TravelHistories = new List<TravelHistory> { new TravelHistory() },
                LoanHistories = new List<LoanHistory> { new LoanHistory() },
                LanguageSkill = new List<LanguageSkill> { new LanguageSkill() },
                ExperienceLetters = new List<ExperienceLetter> { new ExperienceLetter() },
                ProfessionalQualification = new List<ProfessionalQualification> { new ProfessionalQualification() }
            };

            return View(viewModel);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle Profile Photo Upload before saving
                if (model.ProfilePhoto != null && model.ProfilePhoto.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ProfilePhoto.FileName);
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    Directory.CreateDirectory(uploadsFolder); // Ensures the folder exists
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfilePhoto.CopyToAsync(fileStream);
                    }
                    model.Employee.ImagePath = "/images/" + uniqueFileName;
                }

                // Accessing the database transaction engine safely
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // 1. Save the primary Employee master record first
                    _context.Employees.Add(model.Employee);
                    await _context.SaveChangesAsync(); // Generates the EmployeeId identity key

                    int generatedId = model.Employee.EmployeeId;

                    // 2. Bind the primary identity key to all 1-to-1 navigation objects
                    model.EmploymentDetails.EmployeeId = generatedId;
                    model.ParentInformation.EmployeeId = generatedId;
                    model.SocialMediaInformation.EmployeeId = generatedId;
                    model.DrivingLicense.EmployeeId = generatedId;
                    model.TaxInformation.EmployeeId = generatedId;

                    // 3. Queue up the 1-to-1 inserts inside the context tracking engine
                    _context.EmploymentDetails.Add(model.EmploymentDetails);
                    _context.ParentInformations.Add(model.ParentInformation);
                    _context.SocialMediaInformations.Add(model.SocialMediaInformation);
                    _context.DrivingLicenses.Add(model.DrivingLicense);
                    _context.TaxInformations.Add(model.TaxInformation);

                    // 4. Loop and bind one-to-many collection models safely
                    if (model.Addresses != null && model.Addresses.Any())
                    {
                        foreach (var address in model.Addresses)
                        {
                            // Only save if they actually typed an address line
                            if (!string.IsNullOrWhiteSpace(address.AddressLine))
                            {
                                address.EmployeeId = generatedId;
                                _context.AddressInformations.Add(address);
                            }
                        }
                    }

                    if (model.Educations != null && model.Educations.Any())
                    {
                        foreach (var education in model.Educations)
                        {
                            // Only save if they actually typed a degree name
                            if (!string.IsNullOrWhiteSpace(education.DegreeName))
                            {
                                education.EmployeeId = generatedId;
                                _context.EducationInformations.Add(education);
                            }
                        }
                    }

                    // 5. Commit everything to the physical database at once
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", $"Failed to compile and commit the database transaction: {ex.Message}");
                }
            }

            // If validation goes wrong, reload the form with user selections preserved
            return View(model);
        }

        // ==========================================================================
        // 4. EDIT OPERATION (GET & POST)
        // ==========================================================================
        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Populate our unified viewmodel with the existing database values
            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                ParentInformation = employee.ParentInformation ?? new ParentInformation(),
                EmploymentDetails = employee.EmploymentDetails ?? new EmploymentDetails(),
                SocialMediaInformation = employee.SocialMediaInformation ?? new SocialMediaInformation(),
                DrivingLicense = employee.DrivingLicense ?? new DrivingLicense(),
                TaxInformation = employee.TaxInformation ?? new TaxInformation(),
                Addresses = employee.Addresses?.ToList() ?? new System.Collections.Generic.List<AddressInformation>(),
                Educations = employee.Educations?.ToList() ?? new System.Collections.Generic.List<EducationInformation>()
            };

            // Guarantee at least one blank row so the user can add new data if they didn't have any before
            if (viewModel.Addresses == null || !viewModel.Addresses.Any())
            {
                viewModel.Addresses = new System.Collections.Generic.List<AddressInformation> { new AddressInformation() };
            }
            if (viewModel.Educations == null || !viewModel.Educations.Any())
            {
                viewModel.Educations = new System.Collections.Generic.List<EducationInformation> { new EducationInformation() };
            }

            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeFormViewModel model)
        {
            if (id != model.Employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle Profile Photo Upload before saving
                    if (model.ProfilePhoto != null && model.ProfilePhoto.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ProfilePhoto.FileName);
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        Directory.CreateDirectory(uploadsFolder);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfilePhoto.CopyToAsync(fileStream);
                        }

                        model.Employee.ImagePath = "/images/" + uniqueFileName;
                    }

                    // 1. We update the core employee and ALL related 1-to-1 tracking models
                    _context.Employees.Update(model.Employee);
                    _context.EmploymentDetails.Update(model.EmploymentDetails);
                    _context.ParentInformations.Update(model.ParentInformation);
                    _context.SocialMediaInformations.Update(model.SocialMediaInformation);
                    _context.DrivingLicenses.Update(model.DrivingLicense);
                    _context.TaxInformations.Update(model.TaxInformation);

                    // 2. Loop through Lists and update them based on their exact IDs
                    if (model.Addresses != null)
                    {
                        foreach (var address in model.Addresses)
                        {
                            if (!string.IsNullOrWhiteSpace(address.AddressLine))
                            {
                                if (address.AddressId == 0) // New item added via the empty row
                                {
                                    address.EmployeeId = model.Employee.EmployeeId;
                                    _context.AddressInformations.Add(address);
                                }
                                else // Existing item being updated
                                {
                                    _context.AddressInformations.Update(address);
                                }
                            }
                        }
                    }

                    if (model.Educations != null)
                    {
                        foreach (var education in model.Educations)
                        {
                            if (!string.IsNullOrWhiteSpace(education.DegreeName))
                            {
                                if (education.EducationId == 0) // New item added via the empty row
                                {
                                    education.EmployeeId = model.Employee.EmployeeId;
                                    _context.EducationInformations.Add(education);
                                }
                                else // Existing item being updated
                                {
                                    _context.EducationInformations.Update(education);
                                }
                            }
                        }
                    }

                    // 3. Commit the changes to the database
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unable to save changes: {ex.Message}");
                }
            }

            // If validation fails, return the form with their inputs preserved
            return View(model);
        }

        // ==========================================================================
        // 5. DELETE OPERATION (GET & POST)
        // ==========================================================================
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to delete employee due to data constraint properties: {ex.Message}");

                // Re-fetch employee data to show on the confirmation page again safely
                var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
                return View(employee);
            }
        }
    }
}


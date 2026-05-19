using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HRManager.Controllers
{
    public class EmployeeController : Controller
    {
        // Define a readonly field for the database context
        private readonly HRManagerDbContext db;

        // Inject the DbContext via the constructor (.NET 9 standard)
        public EmployeeController(HRManagerDbContext context)
        {
            db = context;
        }

        // GET: /Employee
        public IActionResult Index(string searchString)
        {
            var employees = db.Employees.Include(e => e.EmploymentDetails).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.FullName.Contains(searchString) || e.EmployeeCode.Contains(searchString));
            }

            return View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var employee = db.Employees
                .Include(e => e.ParentInformation)
                .Include(e => e.SocialMediaInformation)
                .Include(e => e.EmploymentDetails)
                .Include(e => e.AddressInformation)
                .SingleOrDefault(e => e.EmployeeId == id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        // GET: /Employee/Create
        public IActionResult Create()
        {
            return View(new Employee());
        }

        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Ensure Unique Constraints (Basic check)
                if (db.Employees.Any(e => e.EmployeeCode == employee.EmployeeCode))
                {
                    ModelState.AddModelError("EmployeeCode", "Employee Code already exists.");
                    return View(employee);
                }

                employee.CreatedDate = DateTime.Now;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var employee = db.Employees
                .Include(e => e.ParentInformation)
                .Include(e => e.SocialMediaInformation)
                .Include(e => e.EmploymentDetails)
                .Include(e => e.AddressInformation)
                .SingleOrDefault(e => e.EmployeeId == id);

            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: /Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ModifiedDate = DateTime.Now;
                db.Entry(employee).State = EntityState.Modified;

                if (employee.ParentInformation != null) db.Entry(employee.ParentInformation).State = EntityState.Modified;
                if (employee.SocialMediaInformation != null) db.Entry(employee.SocialMediaInformation).State = EntityState.Modified;
                if (employee.EmploymentDetails != null) db.Entry(employee.EmploymentDetails).State = EntityState.Modified;
                if (employee.AddressInformation != null) db.Entry(employee.AddressInformation).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var employee = db.Employees.Find(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = db.Employees
                .Include(e => e.ParentInformation)
                .Include(e => e.SocialMediaInformation)
                .Include(e => e.EmploymentDetails)
                .Include(e => e.AddressInformation)
                .SingleOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                // Delete related entities manually since Cascade delete behaviors are restricted for safety
                if (employee.ParentInformation != null) db.ParentInformations.Remove(employee.ParentInformation);
                if (employee.SocialMediaInformation != null) db.SocialMediaInformations.Remove(employee.SocialMediaInformation);
                if (employee.EmploymentDetails != null) db.EmploymentDetails.Remove(employee.EmploymentDetails);
                if (employee.AddressInformation != null) db.AddressInformations.Remove(employee.AddressInformation);

                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
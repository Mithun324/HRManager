using HRManager.Data;
using HRManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRManager.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRManagerDbContext _context;

        public EmployeeRepository(HRManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(string? searchString)
        {
            var query = _context.Employees
                .Include(e => e.EmploymentDetails)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => !(!e.FullName.Contains(searchString) && !e.EmployeeCode.Contains(searchString)));
            }

            return await query.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.EmploymentDetails)
                .Include(e => e.ParentInformation)
                .Include(e => e.SocialMediaInformation)
                .Include(e => e.DrivingLicense)
                .Include(e => e.TaxInformation)
                .Include(e => e.Addresses)
                .Include(e => e.Educations)
                .Include(e => e.Trainings)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task AddEmployeeAsync(Employee employee, EmploymentDetails details, ParentInformation parents, SocialMediaInformation social, DrivingLicense license, TaxInformation tax)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(); // Generates the EmployeeId

                // Bind the foreign keys
                details.EmployeeId = employee.EmployeeId;
                parents.EmployeeId = employee.EmployeeId;
                social.EmployeeId = employee.EmployeeId;
                license.EmployeeId = employee.EmployeeId;
                tax.EmployeeId = employee.EmployeeId;

                _context.EmploymentDetails.Add(details);
                _context.ParentInformations.Add(parents);
                _context.SocialMediaInformations.Add(social);
                _context.DrivingLicenses.Add(license);
                _context.TaxInformations.Add(tax);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
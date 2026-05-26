using HRManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManager.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(string? searchString);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee, EmploymentDetails details, ParentInformation parents, SocialMediaInformation social, DrivingLicense license, TaxInformation tax);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
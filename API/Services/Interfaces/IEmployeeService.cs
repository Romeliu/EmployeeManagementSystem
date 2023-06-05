using API.Domain;
using API.DTO;

namespace API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDTO);
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name);
        Task<IEnumerable<Employee>> GetAllAsync();
        void DeleteEmpoyeeAsync(Employee employee);
        void CheckInAsync(Employee employee, DateTime time);
    }
}
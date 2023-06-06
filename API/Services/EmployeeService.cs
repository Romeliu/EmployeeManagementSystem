using System.Security.Cryptography;
using API.Data.Interfaces;
using API.Domain;
using API.DTO;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.Username = employeeDTO.Username.ToLower();
            using var hmac = new HMACSHA512();
            employee.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(employeeDTO.Password));
            employee.PasswordSalt = hmac.Key;
            return await _employeeRepository.AddAsync(employee);
        }

        public void CheckInAsync(Employee employee, DateTime time)
        {
            _employeeRepository.AddRecordAsync(employee, time);
        }

        public void DeleteEmpoyeeAsync(Employee employee)
        {
            _employeeRepository.DeleteAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name)
        {
            return await _employeeRepository.GetWithNameAsync(name);
        }
    }
}
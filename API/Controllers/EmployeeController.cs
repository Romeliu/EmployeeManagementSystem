using System.Security.Claims;
using API.Domain;
using API.DTO;
using API.Extensions;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            return Ok(await _employeeService.AddEmployeeAsync(employeeDTO, 1));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAsync()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetEmployeeAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeWithNameAsync(string name)
        {
            return Ok(await _employeeService.GetEmployeesByNameAsync(name));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            var check = await _employeeService.GetByIdAsync(id);

            if (check == null) return NotFound();

            _employeeService.DeleteEmpoyeeAsync(check);

            return Ok();
        }

        [HttpPost("checkIn")]
        public async Task<ActionResult<Employee>> CheckInAsync()
        {
            var employee = await _employeeService.GetByIdAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));

            if (employee == null) return NotFound();

            _employeeService.CheckInAsync(employee, DateTime.Now);

            return Ok();
        }
    }
}
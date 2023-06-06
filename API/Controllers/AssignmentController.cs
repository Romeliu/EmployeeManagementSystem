using API.Domain;
using API.DTO;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AssignmentController : BaseApiController
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public AssignmentController(IAssignmentService assignmentService,
            IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [HttpPost("{employeeId}")]
        public async Task<ActionResult<Assignment>> AddAssignmentAsync(AssignmentDTO assignmentDTO, int employeeId)
        {
            return Ok(await _assignmentService.AddAssignmentAsync(assignmentDTO, employeeId));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAssignmentAsync(Assignment assignment)
        {
            var check = await _assignmentService.GetByIdAsync(assignment.Id);

            if (check == null) return NotFound();

            _assignmentService.DeleteAssignmetAsync(assignment);

            return Ok();
        }

        [HttpPost("MarkAsComplete")]
        public async Task<ActionResult<Assignment>> MarkAsComplete(Assignment assignment)
        {
            var check = await _assignmentService.GetByIdAsync(assignment.Id);

            if (check == null) return NotFound();

            return Ok(await _assignmentService.MarkCompleted(assignment));
        }


        [HttpGet("{completed}/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments(int employeeId, bool completed)
        {
            var check = await _employeeService.GetByIdAsync(employeeId);

            if (check == null) return NotFound();

            return Ok(await _assignmentService.GetAssignmentsAsync(completed, employeeId));
        }
    }
}
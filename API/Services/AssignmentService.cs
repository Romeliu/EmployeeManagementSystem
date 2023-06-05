using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.DTO;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<Assignment> AddAssignmentAsync(AssignmentDTO assignmentDTO, int EmployeeId)
        {
            var assignment = _mapper.Map<Assignment>(assignmentDTO);
            assignment.Completed = false;
            return await _assignmentRepository.AddAsync(assignment);
        }

        public void DeleteAssignmetAsync(Assignment assignment)
        {
            _assignmentRepository.DeleteAsync(assignment);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(bool completed, int employeeId)
        {
           return await _assignmentRepository.GetAssignmentsAsync(completed, employeeId);
        }

        public async Task<Assignment> MarkCompleted(Assignment assignment)
        {
            assignment.Completed = true;
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        
    }
}
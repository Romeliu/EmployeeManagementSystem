using API.DTO;

namespace API.Services.Interfaces
{
    public interface IAssignmentService
    {
        public void DeleteAssignmetAsync(Assignment assignment);
        Task<IEnumerable<Assignment>> GetAssignmentsAsync(bool completed, int employeeId);
        Task<Assignment> MarkCompleted(Assignment assignment);
        Task<Assignment> AddAssignmentAsync(AssignmentDTO assignmentDTO, int employeeId);
        Task<Assignment> GetByIdAsync(int id);
    }
}
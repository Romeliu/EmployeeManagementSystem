namespace API.Data.Interfaces
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        public Task<IEnumerable<Assignment>> GetAssignmentsAsync(bool completed, int employeeId);
    }
}
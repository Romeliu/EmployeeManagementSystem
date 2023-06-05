using API.Domain;

namespace API.Data.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<IEnumerable<Employee>> GetWithNameAsync(string name);
        public void AddRecordAsync(Employee employee, DateTime time);
    }
}
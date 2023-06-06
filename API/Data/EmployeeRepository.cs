using API.Data.Interfaces;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddAsync(Employee entity)
        {
            await _context.
            Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void AddRecordAsync(Employee employee, DateTime time)
        {
            var searched = await _context.Employees.Where(e => e.Id == employee.Id).Include(e => e.Loggers).FirstOrDefaultAsync();
            Logger newLog = new Logger();
            newLog.CheckInHour = time.Hour;
            newLog.EmployeeId = employee.Id;

            var record = _context.Records.Where(r => r.Date.Date == time.Date).FirstOrDefault();
            if (record == null)
            {
                record = new Record { Date = time.Date };
                await _context.Records.AddAsync(record);
            }
            newLog.RecordId = record.Id;;
            searched.Active = true;
            searched.Loggers.Add(newLog);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> DeleteAsync(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetWithNameAsync(string name)
        {
            name = name.ToLower();
            return await _context.Employees
                .Where(u => (u.Username.ToLower().Contains(name)
                    || u.Firstname.ToLower().Contains(name)
                    || u.Lastname.ToLower().Contains(name)))
                .ToListAsync();
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
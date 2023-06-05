using API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly DataContext _context;

        public AssignmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Assignment> AddAsync(Assignment entity)
        {
            await _context.Assignments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Assignment> DeleteAsync(Assignment entity)
        {
            _context.Assignments.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _context.Assignments.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(bool completed, int employeeId)
        {
            return await _context.Assignments.Where(u => (u.Completed  && u.EmployeeId == employeeId)).ToListAsync();
        }

        public async Task<Assignment> UpdateAsync(Assignment entity)
        {
             _context.Assignments.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
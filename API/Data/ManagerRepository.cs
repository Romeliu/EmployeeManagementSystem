using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DataContext _context;

        public ManagerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Manager> AddAsync(Manager entity)
        {
            await _context.
            Managers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Manager> DeleteAsync(Manager entity)
        {
            _context.Managers.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _context.Managers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Manager> UpdateAsync(Manager entity)
        {
            _context.Managers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
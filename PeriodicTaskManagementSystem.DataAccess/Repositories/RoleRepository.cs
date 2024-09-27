using Microsoft.EntityFrameworkCore;
using PeriodicTaskManagementSystem.DataAccess.Data;
using PeriodicTaskManagementSystem.DataAccess.Entities;
using PeriodicTaskManagementSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Role role)
        {
            var roleinDb = await _context.Roles.FindAsync(role.Id);
            if (roleinDb != null)
            {
                roleinDb.Name = role.Name;
                roleinDb.Description = role.Description;

                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(Guid id)
        {
            var roleinDb = await _context.Roles.FindAsync(id);

            if (roleinDb != null)
            {
                _context.Roles.Remove(roleinDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

    }
}

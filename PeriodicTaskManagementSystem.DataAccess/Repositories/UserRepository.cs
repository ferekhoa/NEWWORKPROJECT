using Microsoft.EntityFrameworkCore;
using PeriodicTaskManagementSystem.DataAccess.Data;
using PeriodicTaskManagementSystem.DataAccess.Entities;
using PeriodicTaskManagementSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            var userinDb = await _context.Users.FindAsync(user.Id);
            if (userinDb != null)
            {
                userinDb.FirstName = user.FirstName;
                userinDb.LastName = user.LastName;
                userinDb.Username = user.Username;
                userinDb.Email = user.Email;
                userinDb.Password = user.Password;
                userinDb.Phone = user.Phone;
                userinDb.UpdatedAt = DateTime.Now;
                userinDb.RoleId = user.RoleId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var userinDb = await _context.Users.FindAsync(id);

            if (userinDb != null)
            {
                _context.Users.Remove(userinDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }


    }
}

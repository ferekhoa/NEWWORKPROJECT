using PeriodicTaskManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.DataAccess.Interfaces
{
    public interface IUserRepository
    {
            Task<IEnumerable<User>> GetAllAsync();
            Task<User> GetByIdAsync(Guid id);
            Task AddAsync(User user);
            Task UpdateAsync(User user);
            Task DeleteAsync(Guid id);
            Task<Role> GetRoleByNameAsync(string name);
    }
}

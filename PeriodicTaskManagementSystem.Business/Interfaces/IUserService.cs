using PeriodicTaskManagementSystem.Business.DTOs.Users;
using PeriodicTaskManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task AddAsync(AddUserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);

    }
}

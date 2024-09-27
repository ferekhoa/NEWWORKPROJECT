using Microsoft.EntityFrameworkCore;
using PeriodicTaskManagementSystem.Business.DTOs.Users;
using PeriodicTaskManagementSystem.Business.Interfaces;
using PeriodicTaskManagementSystem.DataAccess.Data;
using PeriodicTaskManagementSystem.DataAccess.Entities;
using PeriodicTaskManagementSystem.DataAccess.Interfaces;
using PeriodicTaskManagementSystem.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddAsync(AddUserDto adduserDto)
        {
            var role = await _userRepository.GetRoleByNameAsync(adduserDto.Role.Name);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with name {adduserDto.Role.Name} was not found!");
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(adduserDto.Password);

            var user = new User()
            {
                FirstName = adduserDto.FirstName,
                LastName = adduserDto.LastName,
                Username = adduserDto.Username,
                Email = adduserDto.Email,
                Password = passwordBytes,
                Phone = adduserDto.Phone,
                Role = role,
            };
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {userDto.Id} was not found!");
            }
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Phone = userDto.Phone;
            user.Role = userDto.Role;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} was not found!");
            }
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                    Role = user.Role,
                }); 
            }
            return usersDto;
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} was not found!");
            }
            var userDto = new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Role = user.Role,
            };
            return userDto;
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }

    }
}

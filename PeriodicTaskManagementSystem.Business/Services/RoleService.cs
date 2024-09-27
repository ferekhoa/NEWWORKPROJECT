using PeriodicTaskManagementSystem.Business.DTOs.Roles;
using PeriodicTaskManagementSystem.Business.Interfaces;
using PeriodicTaskManagementSystem.DataAccess.Entities;
using PeriodicTaskManagementSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.Business.Services
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task AddAsync(RoleDto roleDto)
        {
            var role = new Role()
            {
                Name = roleDto.Name,
                Description = roleDto.Description,
            };
            await _roleRepository.AddAsync(role);

        }

        public async Task UpdateAsync(RoleDto roleDto)
        {
            var role = await _roleRepository.GetByIdAsync(roleDto.Id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {roleDto.Id} was not found!");
            }

            role.Name = roleDto.Name;
            role.Description = roleDto.Description;

            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {id} was not found!");
            }
            await _roleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            var rolesDto = new List<RoleDto>();
            foreach (var role in roles)
            {
                rolesDto.Add(new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                });
            }
            return rolesDto;
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with Id {id} was not found!");
            }
            var roleDto = new RoleDto()
            {
                Name = role.Name,
                Description = role.Description,
            };
            return roleDto;
        }
    }
}

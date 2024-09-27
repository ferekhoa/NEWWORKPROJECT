using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.Business.DTOs.Roles
{
    public class RoleDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(30)]
        public required string Name { get; set; }
        [Required, MaxLength(250)]
        public required string Description { get; set; }
    }
}

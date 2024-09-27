using PeriodicTaskManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.Business.DTOs.Users
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(30)]
        public required string FirstName { get; set; }

        [Required, MaxLength(30)]
        public required string LastName { get; set; }

        [Required, MaxLength(30)]
        public required string Username { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required byte[] Password { get; set; }

        [Required, MaxLength(12), Phone]
        public required string Phone { get; set; }
        public required Role Role { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTaskManagementSystem.DataAccess.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(30)]
        public required string FirstName { get; set; }

        [Required, MaxLength(30)]
        public required string LastName { get; set; }

        [Required, MaxLength (30)]
        public required string Username { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required byte[] Password { get; set; }

        [Required, MaxLength(12), Phone]
        public required string Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public required Role Role { get; set; }



    }
}

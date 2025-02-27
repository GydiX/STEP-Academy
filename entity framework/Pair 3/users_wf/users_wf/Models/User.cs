using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace users_wf.Models
{
    public class User
    {
        [Key]
        public required string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        public required string Email { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Range(0, 200)]
        [DefaultValue(0)]
        public int Age { get; set; }

        public required string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
    }
}

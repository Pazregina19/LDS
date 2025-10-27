using System;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AdminDTO : UserDTO
    {

    }

    public class AdminCreateDTO
    {
        [Required]
        [StringLength(20)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
    
    public class AdminUpdateDTO : IPasswordUpdateDTO
    {
        [StringLength(20)]
        public string? Nome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        string IPasswordUpdateDTO.currentPassword { get ; set ; }
        string IPasswordUpdateDTO.newPassword { get; set; }
    }
}
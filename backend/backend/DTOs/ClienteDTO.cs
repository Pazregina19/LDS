using System;
using System.ComponentModel.DataAnnotations;
using backend.Models;
using backend.Models.Enums;

namespace backend.DTOs
{
    public class ClienteDTO : UserDTO
    {
        [StringLength(13)]
        public string? Contacto { get; set; }

        [StringLength(255)]
        public string? Morada { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }
             
        [Required] 
        public UserStatus Status { get; set; }

    }

    public class ClienteCreateDTO
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
        [StringLength(13)]
        public string? Contacto { get; set; }

        [StringLength(255)]
        public string? Morada { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

    }

    public class ClienteUpdateDTO : IPasswordUpdateDTO
    {
        [Required]
        [StringLength(20)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
        [StringLength(13)]
        public string? Contacto { get; set; }

        [StringLength(255)]
        public string? Morada { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        string IPasswordUpdateDTO.currentPassword { get ; set ; }
        string IPasswordUpdateDTO.newPassword { get; set; }

        public UserStatus? Status { get; set; }
    }
}
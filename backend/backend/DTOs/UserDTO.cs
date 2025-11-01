using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public abstract class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Usertype { get; set; } = string.Empty;

        public DateTime DataRegisto { get; set; }

    }
}
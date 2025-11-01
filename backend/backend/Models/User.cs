using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;
namespace backend.Models
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "character varying(70)")]
        public string? Password { get; set; }

        [Required]
        [Column(TypeName = "character varying(20)")]
        public UserType UserType { get; set; }

         [Required]
        public DateTime DataRegisto { get; set; }

        public User()
        {
            DataRegisto = DateTime.UtcNow; // UtcNow used to avoid time zone problems
        }



    }
}
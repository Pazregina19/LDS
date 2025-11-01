using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Administrador", Schema = "dbo")]
    public class Administrador
    {
        [Key]
        public int administrador_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string email { get; set; }

        [Required]
        [MaxLength(100)]
        public string password { get; set; }

        //relação 1:1 com Login_Administrador
        public LogAdmin? Login_Administrador { get; set; }
    }
}
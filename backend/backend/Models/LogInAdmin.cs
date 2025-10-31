using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Login_Administrador", Schema = "dbo")]
    public class LogAdmin
    {
        [Key]
        public int loginAdmin_ID { get; set; }

        [ForeignKey("Administrador")]
        public int administrador_ID { get; set; }

        public Administrador? Administrador { get; set; }
    }
}
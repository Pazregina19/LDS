using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Login_Cliente", Schema = "dbo")]
    public class LogCliente
    {
        [Key]
        public int login_ID { get; set; }

        [ForeignKey("Cliente")]
        public int cliente_ID { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
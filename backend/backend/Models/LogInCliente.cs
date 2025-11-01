using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

namespace backend.Models
{
    [Table("LoCliente")]
    public class LogCliente
    {
        [Key]
        public int IdLog;

        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public DateTime data;
=======
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
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd

        public Cliente? Cliente { get; set; }
    }
}
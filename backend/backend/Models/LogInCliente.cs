using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Cliente? Cliente { get; set; }
    }
}
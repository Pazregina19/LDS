using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("LogEstafeta")]
   
    public class LogEstafeta
    {
        [Key]
        public int IdLog { get; set; }

        [Required]
        [ForeignKey("Estafeta")]
        public int IdEstafeta { get; set; }

        public DateTime data { get; set; }

        public Estafeta? EStafeta { get; set; }

        
    }

}
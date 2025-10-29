using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("LogAdmin") ]
    public class LogAdmin
    {
        [Key]
        public int IdLog;

        [Required]
        [ForeignKey("LogAdmin")]
        public int IdAdmin { get; set; }

        public DateTime data { get; set; }

        public Admin? Admin { get; set; }

        
    }
}
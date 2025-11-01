using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

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

        
=======
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
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
    }
}
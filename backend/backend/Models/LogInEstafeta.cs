using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

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

        
=======
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Login_Estafeta", Schema = "dbo")]
    public class LogEstafeta
    {
        [Key]
        public int loginEst_ID { get; set; }

        [ForeignKey("Estafeta")]
        public int estafeta_ID { get; set; }

        public Estafeta? Estafeta { get; set; }
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
    }

}
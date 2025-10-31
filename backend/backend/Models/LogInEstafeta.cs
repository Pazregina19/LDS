using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}
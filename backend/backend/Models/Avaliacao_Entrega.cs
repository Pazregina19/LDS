using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Avaliacao_Entrega", Schema = "dbo")]
    public class Avaliacao_Entrega
    {
        [Key]
        public int avaliacao_ID { get; set; }

        [ForeignKey("Entrega")]
        public int entrega_ID { get; set; }

        [ForeignKey("Cliente")]
        public int cliente_ID { get; set; }

        [ForeignKey("Estafeta")]
        public int estafeta_ID { get; set; }

        [Required]
        public DateTime data_avaliacao { get; set; }

        [Required]
        public int nota { get; set; }

        //relações
        public Entrega? Entrega { get; set; }
        public Cliente? Cliente { get; set; }
        public Estafeta? Estafeta { get; set; }
    }
}
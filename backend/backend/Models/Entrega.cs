using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Entrega", Schema = "dbo")]
    public class Entrega
    {
        [Key]
        public int entrega_ID { get; set; }

        [ForeignKey("Disponibilidade_Estafeta")]
        public int? disponibilidade_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string estado { get; set; }

        //relações
        public Disponibilidade_Estafeta? Disponibilidade_Estafeta { get; set; }
        public ICollection<Avaliacao_Entrega> Avaliacoes { get; set; }
    }
}
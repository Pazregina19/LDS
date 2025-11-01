using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Disponibilidade_Estafeta", Schema = "dbo")]
    public class Disponibilidade_Estafeta
    {
        [Key]
        public int disponibilidade_ID { get; set; }

        [Required]
        [ForeignKey("Entrega")]
        public int? entrega_ID { get; set; }

        [Required]
        public decimal preco { get; set; }

        [Required]
        public TimeSpan tempo_esperado { get; set; }

        public Entrega? Entrega { get; set; }
    }
}
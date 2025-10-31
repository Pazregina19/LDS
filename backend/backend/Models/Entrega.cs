using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Entrega")]
    public class Entrega
    {
        [Key]
        public int EntregaId { get; set; }

        [Required]
        [ForeignKey("Proposta")]
        public int PropostaId { get; set; }
    }
}
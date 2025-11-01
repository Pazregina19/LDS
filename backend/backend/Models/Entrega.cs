using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

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
=======
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
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Estafeta", Schema = "dbo")]
    public class Estafeta
    {
        [Key]
        public int estafeta_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        [MaxLength(100)]
        public string password { get; set; }

        [MaxLength(15)]
        public string contacto { get; set; }

        [MaxLength(20)]
        public string matricula { get; set; }

        [MaxLength(50)]
        public string marca_veiculo { get; set; }

        //relações
        public LogEstafeta? Login_Estafeta { get; set; }
        public ICollection<Localizacoes>? Localizacoes { get; set; }
        public ICollection<Avaliacao_Entrega>? Avaliacoes { get; set; }
    }
}
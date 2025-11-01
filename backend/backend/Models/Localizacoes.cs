using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Localizacoes", Schema = "dbo")]
    public class Localizacoes
    {
        [Key]
        public int localizacao_ID { get; set; }

        [ForeignKey("Encomenda")]
        public int encomenda_ID { get; set; }

        [ForeignKey("Estafeta")]
        public int estafeta_ID { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }

        public DateTime data_hora { get; set; }

        //relações
        public Encomenda? Encomenda { get; set; }
        public Estafeta? Estafeta { get; set; }
    }
}
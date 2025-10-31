using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Encomenda", Schema = "dbo")]
    public class Encomenda
    {
        [Key]
        public int encomenda_ID { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int cliente_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Origem { get; set; } 

        [Required]
        [StringLength(100)]
        public string Destino { get; set; } 

        [Required]
        [StringLength(20)]
        public string Peso { get; set; } 

        [Required]
        [StringLength(20)]
        public string Volume { get; set; } 

        [StringLength(50)]
        public string? Descricao { get; set; } 

        [StringLength(20)]
        public string? TempoEstimado { get; set; }

        //relações
        public Cliente? Cliente { get; set; }
        public ICollection<Localizacoes>? Localizacoes { get; set; }

        
    }
   
}
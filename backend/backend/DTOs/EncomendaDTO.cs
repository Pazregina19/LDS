using System;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class EncomendaDTO
    {
        public int EncomendaId { get; set; }
        public int ClienteId { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Peso { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string TempoEstimado { get; set; } = string.Empty;
    }

    public class EncomendaCreateDTO
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Origem { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Destino { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Peso { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Volume { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Descricao { get; set; } = string.Empty;

        [StringLength(20)]
        public string? TempoEstimado { get; set; } = string.Empty;

    }
    
    public class EncomendaUpdateDTO
    {
        [StringLength(100)]
        public string? Origem { get; set; }

        [StringLength(100)]
        public string? Destino { get; set; }

        [StringLength(20)]
        public string? Peso { get; set; }

        [StringLength(20)]
        public string? Volume { get; set; }

        [StringLength(50)]
        public string? Descricao { get; set; }

        [StringLength(20)]
        public string? TempoEstimado { get; set; }

    }
}
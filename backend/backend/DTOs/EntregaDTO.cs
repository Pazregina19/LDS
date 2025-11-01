using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;

namespace backend.DTOs
{
    public class EntregaDTO
    {
        public int EntregaId { get; set; }
        public int DisponibilidadeId { get; set; }
        public EntregaStatus Status { get; set; }

    }

    public class EntregaEstafetaDTO
    {
        public int EntregaId { get; set; }
        public int EstafetaId { get; set; }
        public int DisponibilidadeId { get; set; }
        public EntregaStatus Status { get; set; }

    }

    public class EntregaCreateDTO
    {
        [Required]
        public int DisponibilidadeId { get; set; }
        public EntregaStatus Status { get; set; }

    }

    public class EntregaUpdateDTO
    {
        [Required]
        public  EntregaStatus Status { get; set; }
    }
}
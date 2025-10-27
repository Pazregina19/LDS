using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Estafeta")]
    public class Estafeta : User
    {
        [StringLength(13)]
        public string? Contacto { get; set; }

        [StringLength(255)]
        public string? Morada { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        public ICollection<LogEstafeta> logEstafetas { get; set; }
        
        public Estafeta() : base()
        {
            UserType = UserType.Estafeta;
        }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Cliente")]
    public class Cliente : User
    {
        [StringLength(13)]
        public string? Contacto { get; set; }

        [StringLength(255)]
        public string? Morada { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        public ICollection<LogCliente>? LogsClientes { get; set; }
        public ICollection<Encomenda>? Encomendas { get; set; }

        public Cliente() : base()
        {
            UserType = UserType.Cliente;
        }
    }
}
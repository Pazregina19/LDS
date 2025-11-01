<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using backend.Models.Enums;

namespace backend.Models
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
<<<<<<< HEAD
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
=======
        [Key]
        public int cliente_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string password { get; set; }

        [MaxLength(200)]
        public string morada { get; set; }

        [MaxLength(10)]
        public string codPostal { get; set; }

        [MaxLength(15)]
        public string contacto { get; set; }

        //relações
        public ICollection<Encomenda>? Encomendas { get; set; }
        public ICollection<Avaliacao_Entrega>? Avaliacoes { get; set; }

        //relação 1:1 com LoginCliente
        public LogCliente? Login_Cliente { get; set; }
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
    }
}
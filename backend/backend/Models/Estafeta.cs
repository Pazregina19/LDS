<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Enums;

namespace backend.Models
{
<<<<<<< HEAD
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

=======
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
>>>>>>> aa1291a192403db68927203d0a5dec76f1da48bd
    }
}
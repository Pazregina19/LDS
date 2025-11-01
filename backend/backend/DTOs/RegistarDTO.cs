

using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.DTOs
{
    public class RegistarDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Contacto { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;

        public Cliente ToCliente() => new Cliente
        {
            Nome = Nome,
            Email = Email,
            Password = Password,
            Contacto = Contacto,
            Morada = Morada,
            CodigoPostal = CodigoPostal

        };

        public Estafeta ToEstafeta() => new Estafeta
        {
            Nome = Nome,
            Email = Email,
            Password = Password,
            Contacto = Contacto,
            Morada = Morada,
            CodigoPostal = CodigoPostal

        };
        
        public Admin ToAdnib() => new Admin
        {
            Nome = Nome,
            Email = Email,
            Password = Password
        };
    }
}
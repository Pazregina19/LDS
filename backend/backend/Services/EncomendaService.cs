using System;
using backend.Interfaces;
using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    /// <summary>
    /// Service responsible for order management in the system
    /// </summary>
    public class EncomendaService : IEncomenda
    {
        private readonly ILogInCliente _logInCliente;
        private readonly ILogInEstafeta _logInEstafeta;

        /// <summary>
        /// Initializes new intance od EncomendaService 
        /// </summary>
        /// <param name="logInCliente"></param>
        /// <param name="logInEstafeta"></param>
        public EncomendaService(ILogInCliente logInCliente, ILogInEstafeta logInEstafeta)
        {
            _logInCliente = logInCliente;
            _logInEstafeta = logInEstafeta;
        }
        
        public async Task<EncomendaDTO> AddEncomendaAsync (EncomendaCreateDTO encomendaDTO)
        {
            if (encomendaDTO == null)
                throw new ArgumentNullException(nameof(encomendaDTO), "Encomenda não pode ser nula");

            var cliente = await _data.Clientes.FindAsync(encomendaDTO.ClienteId);
            if (cliente == null)
                throw new ApplicationException($"Cliente {encomendaDTO.ClienteId} não encontrado");

            var encomenda = new Encomenda
            {
                ClienteId = encomendaDTO.ClienteId,
                Origem = encomendaDTO.Origem,
                Destino = encomendaDTO.Destino,
                Peso = encomendaDTO.Peso,
                Volume = encomendaDTO.Volume,
                Descricao = encomendaDTO.Descricao,
                TempoEstimado = encomendaDTO.TempoEstimado

            };
        }
    }
}
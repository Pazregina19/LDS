using System;
using backend.Interfaces;
using backend.DTOs;
using backend.Models;
using backend.Data;

namespace backend.Services
{
    /// <summary>
    /// Service responsible for order management in the system
    /// </summary>
    public class EncomendaService : IEncomenda
    {
        private readonly AppDbContext _context;
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
           throw new NotImplementedException();
        }

        public Task<List<EncomendaDTO>> GetAllEncomendasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EncomendaDTO> GetEncomendaByIdAsync(int EncomendaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EncomendaDTO>> GetEncomendasByClienteAsync(int ClienteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EncomendaDTO>> GetEncomendasProximoEstafetaAsync(int EstafetaId)
        {
            throw new NotImplementedException();
        }

        public Task<EncomendaDTO> UpdateEncomendasAsync(int EncomendaId, EncomendaUpdateDTO encomendaUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
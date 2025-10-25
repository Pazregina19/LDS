using backend.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace backend.Interfaces
{
    /// <summary>
    /// Interface for all services related to order entity
    /// </summary>
    public interface IEncomenda
    {
        /// <summary>
        /// Adds a new order to the system
        /// </summary>
        /// <param name="encomendaCreateDTO"></param>
        /// <returns> Data of new order </returns>
        Task<EncomendaDTO> AddEncomendaAsync(EncomendaCreateDTO encomendaDTO);

        /// <summary>
        /// Gets all orders by a client id
        /// </summary>
        /// <param name="ClienteId"> client id </param>
        /// <returns>List of all orders associated to a client</returns>
        Task<List<EncomendaDTO>> GetEncomendasByClienteAsync(int ClienteId);

        /// <summary>
        /// Gets all orders disponible near delivery man by id
        /// </summary>
        /// <param name="EstafetaId">Delivery man identifier </param>
        /// <returns>List of all orders disponible near a delivery man</returns>
        Task<List<EncomendaDTO>> GetEncomendasProximoEstafetaAsync(int EstafetaId);

        /// <summary>
        /// Gets all the orders registered in the system
        /// </summary>
        /// <returns>List of all orders</returns>
        Task<List<EncomendaDTO>> GetAllEncomendasAsync();

        /// <summary>
        /// Gets the details of a specific order based on its id
        /// </summary>
        /// <param name="EncomendaId"></param>
        /// <returns>Data of the order associated to the id</returns>
        Task<EncomendaDTO> GetEncomendaByIdAsync(int EncomendaId);

        /// <summary>
        /// Updates the data of  a specific order 
        /// </summary>
        /// <param name="EncomendaId"></param>
        /// <param name="encomendaUpdateDTO"></param>
        /// <returns>Updated data</returns>
        Task<EncomendaDTO> UpdateEncomendasAsync(int EncomendaId, EncomendaUpdateDTO encomendaUpdateDTO);

    }
}
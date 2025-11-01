using backend.DTOs;
using backend.Models;

namespace backend.Interfaces
{

    public interface IEntrega
    {
        /// <summary>
        /// Chose a proposoal for entrega
        /// </summary>
        /// <param name="PropostaId"></param>
        /// <returns></returns>
        Task<EntregaDTO> EscolherPropostaAsync(int PropostaId);

        /// <summary>
        /// Completes a specific entrega
        /// </summary>
        /// <param name="EntregaId"></param>
        /// <returns></returns>
        Task<EntregaDTO> FinalizarEntregaAsync(int EntregaId);

        /// <summary>
        /// Confirms collection of a entrega
        /// </summary>
        /// <param name="EntregaId"></param>
        /// <param name="EstafetaIdd"></param>
        /// <returns></returns>
        Task<EntregaDTO> ConfirmarRecolhaAsync(int EntregaId, int EstafetaIdd);

        /// <summary>
        /// Gets status of entrega
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EntregaDTO> GetEntregaStatusAsync(int id);

        /// <summary>
        /// Creates a new entrega
        /// </summary>
        /// <param name="entregaDto"></param>
        /// <returns></returns>
        Task<EntregaDTO> CreateEntregaAsync(EntregaCreateDTO entregaDto);

        /// <summary>
        /// Updates a entrega
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entregaUpdateDto">Data to be updated</param>
        /// <returns>Success message or error message</returns>
        Task<bool> UpdateEntregaStatusAsync(int id, EntregaUpdateDTO entregaUpdateDto);

        /// <summary>
        /// Gets a estafeta associated to a entrega
        /// </summary>
        /// <param name="EntregaId"></param>
        /// <returns></returns>
        Task<Estafeta?> GetEntregaEstafetaAsync(int EntregaId);

        /// <summary>
        /// Gets a cliente associated to a entrega
        /// </summary>
        /// <param name="EntregaId"></param>
        /// <returns></returns>
        Task<Cliente?> GetEntregaClienteAsync(int EntregaId);

        /// <summary>
        /// Gets a encomenda associated to a entrega
        /// </summary>
        /// <param name="EncomendaId"></param>
        /// <returns></returns>
        Task<Encomenda?> GetEntregaEncomendaAsync(int EncomendaId);

        /// <summary>
        /// Gets all the entregas in the system
        /// </summary>
        /// <returns></returns>
        Task<List<EntregaDTO>> GetAllEntregasAsync();

        /// <summary>
        /// Gets all entregas associated to a estafeta
        /// </summary>
        /// <param name="EstafetaId"></param>
        /// <returns></returns>
        Task<List<EntregaEstafetaDTO>> GetAllEntregasEstafetaAsync(int EstafetaId);

    }
    

    
}
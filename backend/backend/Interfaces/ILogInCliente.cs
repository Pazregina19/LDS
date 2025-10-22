using System;
using backend.Models;

namespace backend.Interfaces
{
    public interface ILogInCliente
    {
        /// <summary>
        /// Interface for clients logins management
        /// </summary>
        /// <param name="ClienteId"></param>
        /// <param name="atividade"></param>
        /// <returns></returns>
        Task<IResult> AddLogInCliente(int ClienteId, string? atividade);

        /// <summary>
        /// Gets all logs of a client
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LogInCliente>> GetAllLogsAsync();
    }
}
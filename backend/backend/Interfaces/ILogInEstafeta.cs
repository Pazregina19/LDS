
using backend.Models;

namespace backend.Interfaces
{
     public interface ILogInEstafeta
    {
        /// <summary>
        /// Interface for estafetas logins management
        /// </summary>
        /// <param name="EstafetaId"></param>
        /// <returns></returns>
        Task<IResult> AddLogInEstafeta(int EstafetaId);

        /// <summary>
        /// Gets all logs of a estafeta
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LogEstafeta>> GetAllLogsAsync();
    }
}
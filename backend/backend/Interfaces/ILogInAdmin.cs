using backend.Models;

namespace backend.Interfaces
{
    public interface ILogInAdmin
    {
        /// <summary>
        /// Interface for estafetas logins management
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns></returns>
        Task<IResult> AddLogInEstafeta(int AdminId);

        /// <summary>
        /// Gets all logs of a estafeta
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LogAdmin>> GetAllLogsAsync();
    }
}
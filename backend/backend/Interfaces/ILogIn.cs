using backend.Models;

namespace backend.Interfaces
{
    
    public interface ILogIn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns>List of logs for clientes</returns>
        Task<List<LogCliente>> GetAllLogsCliente(int AdminId);

        /// <summary>
        /// Gets all the log for Estafetas
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns>List of logs for estafetas</returns>
        Task<List<LogEstafeta>> GetAllLogsEstafetas(int AdminId);

        /// <summary>
        /// Gets all the logs for admin
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns>List of logs for admin</returns>
        Task<List<LogAdmin>> GetAllLogsAdmin(int AdminId);
    }
}
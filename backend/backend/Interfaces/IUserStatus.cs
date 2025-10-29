

namespace backend.Interfaces
{
    /// <summary>
    /// Interface for user status updates service
    /// </summary>
    public interface IUserStatus
    {
        /// <summary>
        /// Activates a user based on id
        /// </summary>
        /// <param name="id"> User Id to be activated</param>
        /// <returns>Returns boolean value if operation succeds</returns>
        Task<bool> ActivateAsync(int id);

        /// <summary>
        /// Inactivates a user based on id
        /// </summary>
        /// <param name="id">User Id to be inactivated</param>
        /// <returns>Returns boolean value if operation succeds</returns>
        Task<bool> InactivateAsync(int id);
    }
}
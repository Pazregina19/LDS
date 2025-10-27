using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DTOs;

namespace backend.Interfaces
{
    /// <summary>
    /// Generic Interface to management users service
    /// </summary>
    /// <typeparam name="TCreateDTIO">DTO Type to create users</typeparam>
    /// <typeparam name="TUpdateDTO">DTO Type to update users</typeparam>
    /// <typeparam name="TDTO">Dto Type to return users data</typeparam>
    
    public interface IUser<TCreateDTIO, TUpdateDTO, TDTO>
    {
        /// <summary>
        /// Authenticates a user based on email and password
        /// </summary>
        /// <param name="email">Users email</param>
        /// <param name="passwword">Users password</param>
        /// <returns>DTO object of authenticaded user</returns>
        TDTO Authenticate(string email, string passwword);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="createDto">DTO pbject with users data to be create</param>
        /// <returns>DTO object of created user</returns>
        Task<TDTO> CreateAsync(TCreateDTIO createDto);

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO object of user</returns>
        TDTO GetById(int id);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>Enumerable with DTO object of users</returns>
        IEnumerable<TDTO> GetAll();

        /// <summary>
        /// Updates existent user data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns>DTO object of updated user</returns>
        Task<TDTO> UpdateAsync(int id, TUpdateDTO updateDTO);
    }
}
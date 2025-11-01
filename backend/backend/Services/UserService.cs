

using backend.DTOs;
using backend.Exxceptions;
using backend.Interfaces;
using backend.Models;

namespace backend.Services
{
    public abstract class UserService<TUser, TCreateDTO, TUpdateDTO, TDTO>
    : IUser<TCreateDTO, TUpdateDTO, TDTO>
    where TUser : User, new()
    where TUpdateDTO : class, IPasswordUpdateDTO
    where TDTO : class
    {
        /// <summary>
        /// Constructor to initialize dependencies
        /// </summary>
        protected readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user based on email and password
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <returns></returns>
        /// <exception cref="AppExceeption">Throws exception if credencials invalid</exception>
        public virtual TDTO Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TDTO> CreateAsync(TCreateDTO createDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TDTO> UpdateAsync(int id, TUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
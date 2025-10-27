using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using backend.DTOs;

namespace backend.Interfaces
{
    /// <summary>
    /// Interface that defines services related to Admin
    /// </summary>
    public interface IAdmin : IUser<AdminCreateDTO, AdminUpdateDTO, AdminDTO>
    {
        //Extends generic interface IUser for admin entity
        //uses specific DTOs to create, update and exhibition
    }
}
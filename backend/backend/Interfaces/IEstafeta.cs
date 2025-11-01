using backend.DTOs;


namespace backend.Interfaces
{
    /// <summary>
    /// Inteface for the services related to the delivery man entity
    /// </summary>
    public interface IEstafeta : IUser<EstafetaCreateDTO, EstafetaUpdateDTO, EstafetaDTO>
    {
        
    }
   
        
    
}
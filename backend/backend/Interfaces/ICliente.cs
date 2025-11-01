using backend.DTOs;


namespace backend.Interfaces
{
    /// <summary>
    /// Inteface for the services related to the delivery man entity
    /// </summary>
    public interface ICliente : IUser<ClienteCreateDTO, ClienteUpdateDTO, ClienteDTO>
    {
        
    }
   
        
    
}
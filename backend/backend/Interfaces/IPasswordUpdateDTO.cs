using System;

namespace backend.DTOs
{
    public interface IPasswordUpdateDTO
    {
        string currentPassword { get; set; }
        string newPassword { get; set; }
    }
}
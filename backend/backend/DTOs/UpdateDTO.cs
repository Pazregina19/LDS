using System;


namespace backend.DTOs
{
    public class UpdateDto
    {
        public string? Nome { get; set; }
        public string? CurrentPassword { get; set; } 
        public string? NewPassword { get; set; } 

    }
}
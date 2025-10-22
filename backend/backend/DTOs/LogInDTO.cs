using System;

namespace backend.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object to transfer user logIn data
    /// </summary>
    public class LogInDto
    {
        /// <summary>
        /// Email of the user whos is trying to log in
        /// Initializing with an empty string
        /// </summary>
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// User password for authentication
        /// Initializing with an empty string
        /// </summary>
        public string password { get; set; } = string.Empty;
    }
}
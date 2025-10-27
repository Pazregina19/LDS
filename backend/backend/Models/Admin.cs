using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Admin")]
    public class Admin : User
    {
        public List<LogAdmin>? LogAdmins { get; set; }

        public Admin() : base()
        {
            UserType = Models.Enums.UserType.Admin;
        }
    }
}
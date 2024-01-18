using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Models.Models
{
    public class User:BaseEntity
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Confirmpwd { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }
    }
}

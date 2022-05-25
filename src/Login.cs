using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace FinalPro.Models
{
    public class Login
        
    {
 
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")] 
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}

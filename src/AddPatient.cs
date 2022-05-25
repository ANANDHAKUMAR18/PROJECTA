using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace FinalPro.Models
{
    public class AddPatient
    {
        [Key]
        [Required]
        public int PatientID { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Sex { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]

        public string DOB { get; set; }

    }
}

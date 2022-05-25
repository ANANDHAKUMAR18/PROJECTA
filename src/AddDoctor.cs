using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace FinalPro.Models
{
    public class AddDoctor
    {
        [Key]
        [Required]
        public int DoctorID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Specialization { get; set; }
        public string VisitingHours { get; set; }
    }
}

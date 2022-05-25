using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalPro.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string Specialization { get; set;}
        [Required]

        public string Doctor { get; set; }
        [Required]
        public string VisitDate { get; set; }
        [Required]
        public string AppointmentTime { get; set; }
    }
}

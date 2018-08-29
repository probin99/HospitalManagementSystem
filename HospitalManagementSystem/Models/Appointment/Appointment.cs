using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.Appointment
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required(ErrorMessage ="Selection Required")]
        [DataType(DataType.Date)]
        public string Date  { get; set; }

        
    }
}
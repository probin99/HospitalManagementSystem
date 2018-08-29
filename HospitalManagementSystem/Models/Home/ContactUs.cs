using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.Home
{
    public class ContactUs
    {
        [Key]
        public int QueryID { get; set; }

        [Required(ErrorMessage ="Full Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Contact Number Required")]
        public string Telephone { get; set; }

        [Required(ErrorMessage ="Message Required")]
        public string Message { get; set; }
    }
}
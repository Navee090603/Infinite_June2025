using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Contact
    {
        public long Id { get; set; }

        [Required]
        [NameValidator]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailValidator]
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Phone]
        public string ContactNumber { get; set; }

        [Required]
        public string Address { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required, StringLength(100)]
        public string LocationName { get; set; }

        [Required]
        public string Address { get; set; }

    }
}

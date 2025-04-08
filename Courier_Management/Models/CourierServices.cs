using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    public class CourierServices
    {
        [Key]
        public int ServiceID { get; set; }

        [Required, StringLength(100)]
        public string ServiceName { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}

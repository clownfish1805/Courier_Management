using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeID { get; set; }

        [Required] 
        [StringLength(255)] 
        public string Name { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [StringLength(20)] 
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(50)] 
        public string Role { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary cannot be negative")]
        public decimal Salary { get; set; }
    }
}

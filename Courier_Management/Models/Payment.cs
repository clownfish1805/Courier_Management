using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int CourierID { get; set; }

        [ForeignKey("CourierID")]
        public Courier Courier { get; set; }

        [Required]
        public int LocationID { get; set; }


        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }


        [ForeignKey("EmpID")]
        public Employee EmployeeID { get; set; }

    }
}

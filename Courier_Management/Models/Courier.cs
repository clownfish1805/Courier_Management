using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    class Courier
    {
        [Key]
        public int CourierID { get; set; }

        [Required, StringLength(255)]
        public string SenderName { get; set; }

        [Required]
        public string SenderAddress { get; set; }

        [Required, StringLength(255)]
        public string ReceiverName { get; set; }

        [Required]
        public string ReceiverAddress { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }

        [Required, StringLength(20)]
        public string TrackingNumber { get; set; }

        [Required]
        public DateOnly DeliveryDate { get; set; }

        [Required]
        public DateOnly ShippedDate { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [ForeignKey("EmpID")]
        public Employee Employee { get; set; }

        [Required]
        public int LocationID { get; set; }

        [ForeignKey("LocationID")]
        public Location Location { get; set; }


        public Courier(int courierID, string senderName, string senderAddress, string receiverName,
               string receiverAddress, double weight, string status, string trackingNumber,
               DateTime deliveryDate, int employeeID, int locationID)
        {
            CourierID = courierID;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = (decimal)weight;
            Status = status;
            TrackingNumber = trackingNumber;
            DeliveryDate = DateOnly.FromDateTime(deliveryDate);
            EmployeeID = employeeID;
            LocationID = locationID;
        }

        public Courier()
        {
        }
    }
}

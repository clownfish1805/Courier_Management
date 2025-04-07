using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.CodingQues
{
    class Task1
    {
        public void ques1()
        {
            Console.Write("Enter order status (Processing/Delivered/Cancelled): ");
            string status = Console.ReadLine();

            if (status.Equals("Delivered", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order has been delivered.");
            }
            else if (status.Equals("Processing", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order is still being processed.");
            }
            else if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order has been cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid status entered.");
            }
        }

        public void ques2()
        {
            Console.Write("Enter parcel weight (in kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            switch (weight)
            {
                case <= 25.0:
                    Console.WriteLine("The parcel is categorized as Light.");
                    break;
                case > 25.0 and <= 50.0:
                    Console.WriteLine("The parcel is categorized as Medium.");
                    break;
                case > 50.0:
                    Console.WriteLine("The parcel is categorized as Heavy.");
                    break;
                default:
                    Console.WriteLine("Invalid weight entered.");
                    break;
            }
        }

        public void ques3()
        {
            string empEmail = "emp@example.com";
            string empPassword = "emp123";

            string custEmail = "cust@example.com";
            string custPassword = "cust123";

            Console.Write("Enter your role (Employee/Customer): ");
            string role = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (role.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                if (email == empEmail && password == empPassword)
                {
                    Console.WriteLine("Employee login successful.");
                }
                else
                {
                    Console.WriteLine("Invalid employee credentials.");
                }
            }
            else if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                if (email == custEmail && password == custPassword)
                {
                    Console.WriteLine("Customer login successful.");
                }
                else
                {
                    Console.WriteLine("Invalid customer credentials.");
                }
            }
            else
            {
                Console.WriteLine("Invalid role entered.");
            }
        }
        public void ques4()
        {
            string[] couriers = { "Courier A", "Courier B", "Courier C" };
            int[] loads = { 5, 3, 8 };
            Console.WriteLine("Enter Shipment weight: ");
            int shipmentWeight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Assigning shipment...");
            for (int i = 0; i < couriers.Length; i++)
            {
                if (loads[i] >= shipmentWeight)
                {
                    Console.WriteLine($"Shipment assigned to {couriers[i]} with capacity {loads[i]}kg.");
                    return;
                }
            }

            Console.WriteLine("No courier available for the shipment.");
        }

        

    }
}

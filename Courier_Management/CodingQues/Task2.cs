using System;
using System.Collections.Generic;

namespace Courier_Management.CodingQues
{
    class Task2
    {
        public void ques5()
        {
            string[] orders = { "TRK123", "TRK124", "TRK125" };


            Console.WriteLine($"Orders for customer: " + Console.ReadLine());
            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine($"Order {i + 1}: {orders[i]}");
            }
        }
        public void ques6()
        {
            string[] customers = { "Alice", "Bob", "Alice", "Charlie", "Bob", "Alice" };
            string[] orders = { "Order #101", "Order #102", "Order #103", "Order #104", "Order #105", "Order #106" };

            Console.Write("Enter customer name to view their orders: ");
            string customerName = Console.ReadLine();

            Console.WriteLine($"\nOrders for {customerName}:");

            bool found = false;

            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i].Equals(customerName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(orders[i]);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No orders found for this customer.");
            }
        }

       
    }
    }

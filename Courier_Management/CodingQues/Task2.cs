using System;
using System.Collections.Generic;

namespace Courier_Management.CodingQues
{
    class Task2
    {
        public void ques5()
        {
            string customerName = "Alice";
            string[] orders = { "TRK123", "TRK124", "TRK125" };

            Console.Write("Enter customer name: ");
            string inputName = Console.ReadLine();

            
            if (inputName == customerName)
            {
                Console.WriteLine($"Orders for {customerName}:");
                for (int i = 0; i < orders.Length; i++)
                {
                    Console.WriteLine("Order " + (i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No orders found for the given customer.");
            }
        }

       public void ques6()
        {
            Dictionary<string, List<string>> customerOrders = new Dictionary<string, List<string>>()
{
    { "Alice", new List<string> { "Order #101", "Order #103" } },
    { "Bob", new List<string> { "Order #102" } },
    { "Charlie", new List<string> { "Order #104", "Order #105" } }
};

            Console.Write("Enter customer name: ");
            string input = Console.ReadLine();

            if (customerOrders.ContainsKey(input))
            {
                Console.WriteLine($"Orders for {input}:");
                foreach (var order in customerOrders[input])
                {
                    Console.WriteLine(order);
                }
            }
            else
            {
                Console.WriteLine("No orders found for this customer.");
            }

        }


    }
    }

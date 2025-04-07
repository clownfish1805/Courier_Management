using System;
using System.Collections.Generic;

namespace Courier_Management.CodingQues
{
    class Task3
    {
       
            public void ques7()
        {
            string[] trackingHistory = new string[5]; 

            Console.WriteLine("Enter tracking updates (locations):");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.Write($"Update {i + 1}: ");
                trackingHistory[i] = Console.ReadLine();
            }

            Console.WriteLine("\nTracking History:");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.WriteLine($"Location {i + 1}: {trackingHistory[i]}");
            }
        }


        public void ques8()
        {
            Console.WriteLine("Finding the nearest available courier for a new order...\n");

            // Courier names
            string[] couriers = { "Courier A", "Courier B", "Courier C", "Courier D" };

            // Array to store distances
            int[] distances = new int[couriers.Length];

            // Get distances from user
            for (int i = 0; i < couriers.Length; i++)
            {
                Console.Write($"Enter distance of {couriers[i]} from the order location (in km): ");
                distances[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Find the courier with the smallest distance
            int minIndex = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                if (distances[i] < distances[minIndex])
                {
                    minIndex = i;
                }
            }

            // Show result
            Console.WriteLine();
            Console.WriteLine("Nearest available courier:");
            Console.WriteLine($"{couriers[minIndex]} - {distances[minIndex]} km away");
        }




    }
}

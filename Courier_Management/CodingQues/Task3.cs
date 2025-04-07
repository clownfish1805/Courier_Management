using System;
using System.Collections.Generic;

namespace Courier_Management.CodingQues
{
    class ParcelTracking
    {
        public List<string> TrackingHistory { get; set; }

        public ParcelTracking()
        {
            TrackingHistory = new List<string>();
        }

        public void AddLocationUpdate(string location)
        {
            TrackingHistory.Add(location);
            Console.WriteLine("Location update added: " + location);
        }

        public void DisplayTrackingHistory()
        {
            Console.WriteLine("Tracking History:");
            foreach (var location in TrackingHistory)
            {
                Console.WriteLine("- " + location);
            }
        }
    }

    class Task3
    {
        public void ques7()
        {
            List<string> locations = new List<string>
            {
                "Warehouse",
                "Checkpoint A",
                "Checkpoint B",
                "Out for Delivery",
                "Destination"
            };

            int i = 0;
            Console.WriteLine("Tracking courier location:");

            while (i < locations.Count)
            {
                Console.WriteLine("Courier is at: " + locations[i]);

                i++;
            }

            Console.WriteLine("Courier has reached the destination.");
        }
        public void ques8()
        {
            ParcelTracking tracking = new ParcelTracking();
            tracking.AddLocationUpdate("Warehouse A");
            tracking.AddLocationUpdate("Distribution Center B");
            tracking.AddLocationUpdate("City Hub C");
            tracking.DisplayTrackingHistory();
        }

       
    }
}

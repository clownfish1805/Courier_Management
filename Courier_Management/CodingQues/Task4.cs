using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Courier_Management.CodingQues
{
    class Task4
    {
        // Task 9: Parcel Tracking using 2D Array
        public void TrackParcel(string trackingNumber)
        {
            string[,] parcels = {
                { "ABC123", "In Transit" },
                { "DEF456", "Out for Delivery" },
                { "GHI789", "Delivered" }
            };

            bool found = false;
            for (int i = 0; i < parcels.GetLength(0); i++)
            {
                if (parcels[i, 0] == trackingNumber)
                {
                    Console.WriteLine($"Tracking Number: {trackingNumber} - Status: {parcels[i, 1]}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Tracking number not found.");
            }
        }

        // Task 10: Customer Data Validation
        public bool ValidateCustomerData(string data, string detail)
        {
            switch (detail.ToLower())
            {
                case "name":
                    return Regex.IsMatch(data, @"^[A-Z][a-zA-Z\s]*$");
                case "address":
                    return !Regex.IsMatch(data, @"[^a-zA-Z0-9\s,]");
                case "phone":
                    return Regex.IsMatch(data, @"^\d{3}-\d{3}-\d{4}$");
                default:
                    return false;
            }
        }

        // Task 11: Address Formatting
        public string FormatAddress(string street, string city, string state, string zip)
        {
            string Capitalize(string input) =>
                string.Join(" ", input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                      .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

            return $"{Capitalize(street)}, {Capitalize(city)}, {state.ToUpper()} - {zip}";
        }

        // Task 12: Order Confirmation Email
        public string GenerateOrderConfirmationEmail(string name, string orderNo, string address, string deliveryDate)
        {
            return $"Dear {name},\n\nThank you for your order!\nOrder Number: {orderNo}\nDelivery Address: {address}\nExpected Delivery Date: {deliveryDate}\n\nRegards,\nCourier Team";
        }

        // Task 13: Calculate Shipping Costs
        public double CalculateShippingCost(string source, string destination, double weight)
        {
            // Dummy logic: use length of city names as a distance proxy
            int distance = Math.Abs(source.Length - destination.Length) * 10 + 50;
            double cost = (distance * 0.5) + (weight * 2);
            return cost;
        }

        // Task 14: Password Generator
        public string GenerateSecurePassword(int length = 12)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "@#$%!&*";

            string allChars = upper + lower + digits + special;
            Random rnd = new Random();
            StringBuilder password = new StringBuilder();

            // Ensure at least one of each type
            password.Append(upper[rnd.Next(upper.Length)]);
            password.Append(lower[rnd.Next(lower.Length)]);
            password.Append(digits[rnd.Next(digits.Length)]);
            password.Append(special[rnd.Next(special.Length)]);

            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[rnd.Next(allChars.Length)]);
            }

            return password.ToString();
        }

        // Task 15: Find Similar Addresses
        public void FindSimilarAddresses(List<string> addresses, string query)
        {
            Console.WriteLine($"Similar addresses to '{query}':");
            foreach (var addr in addresses)
            {
                if (addr.ToLower().Contains(query.ToLower()))
                {
                    Console.WriteLine("- " + addr);
                }
            }
        }

        // Optional: You can create a test method to show how each one works
        public void RunDemo()
        {
            Console.WriteLine("Courier Management - Task 4 Demo");
            Console.WriteLine("Select a question to demo:");
            Console.WriteLine("9  - Parcel Tracking");
            Console.WriteLine("10 - Customer Data Validation");
            Console.WriteLine("11 - Address Formatting");
            Console.WriteLine("12 - Order Confirmation Email");
            Console.WriteLine("13 - Calculate Shipping Cost");
            Console.WriteLine("14 - Password Generator");
            Console.WriteLine("15 - Find Similar Addresses");
            Console.Write("Enter your choice (9–15): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "9":
                    Console.Write("Enter tracking number: ");
                    string trackNo = Console.ReadLine();
                    TrackParcel(trackNo);
                    break;

                case "10":
                    Console.Write("Enter detail type (name/address/phone): ");
                    string detail = Console.ReadLine();
                    Console.Write("Enter data to validate: ");
                    string data = Console.ReadLine();
                    Console.WriteLine("Is Valid: " + ValidateCustomerData(data, detail));
                    break;

                case "11":
                    Console.Write("Enter Street: ");
                    string street = Console.ReadLine();
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter State: ");
                    string state = Console.ReadLine();
                    Console.Write("Enter Zip: ");
                    string zip = Console.ReadLine();
                    Console.WriteLine("Formatted Address: " + FormatAddress(street, city, state, zip));
                    break;

                case "12":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Order Number: ");
                    string orderNo = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    string address = Console.ReadLine();
                    Console.Write("Enter Expected Delivery Date: ");
                    string deliveryDate = Console.ReadLine();
                    Console.WriteLine("\n--- Order Confirmation Email ---");
                    Console.WriteLine(GenerateOrderConfirmationEmail(name, orderNo, address, deliveryDate));
                    break;

                case "13":
                    Console.Write("Enter Source Location: ");
                    string source = Console.ReadLine();
                    Console.Write("Enter Destination Location: ");
                    string destination = Console.ReadLine();
                    Console.Write("Enter Parcel Weight (kg): ");
                    double weight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Shipping Cost: $" + CalculateShippingCost(source, destination, weight));
                    break;

                case "14":
                    Console.Write("Enter Password Length: ");
                    int length = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Generated Password: " + GenerateSecurePassword(length));
                    break;

                case "15":
                    List<string> addresses = new List<string> {
                "123 Main Street",
                "456 Elm Avenue",
                "789 Main Road",
                "321 Oak Drive",
                "Mainland Street"
            };
                    Console.Write("Enter address keyword to search: ");
                    string keyword = Console.ReadLine();
                    FindSimilarAddresses(addresses, keyword);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose between 9–15.");
                    break;
            }
        }

    }
}

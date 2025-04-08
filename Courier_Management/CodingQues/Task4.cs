using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Courier_Management.CodingQues
{
    class Task4
    {
        public string ques9(string trackingNumber)
        {
            string[,] parcels = new string[3, 2]
            {
                { "TRK123", "In Transit" },
                { "TRK456", "Out for Delivery" },
                { "TRK789", "Delivered" }
            };

            for (int i = 0; i < 3; i++)
            {
                if (parcels[i, 0] == trackingNumber)
                {
                    return $"Your parcel status is: {parcels[i, 1]}";
                }
            }

            return "Tracking number not found.";
        }

       
        public bool ques10(string data, string detail)
        {
            if (detail == "name")
            {
                return Regex.IsMatch(data, @"^[A-Z][a-zA-Z\s]*$");
            }
            else if (detail == "address")
            {
                return Regex.IsMatch(data, @"^[a-zA-Z0-9\s,]+$");
            }
            else if (detail == "phone")
            {
                return Regex.IsMatch(data, @"^\d{10}$");
            }
            return false;
        }

       
        public string ques11(string street, string city, string state, string zip)
        {
            string Capitalize(string input)
            {
                string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
                return string.Join(" ", words);
            }

            string formattedStreet = Capitalize(street);
            string formattedCity = Capitalize(city);
            string formattedState = state.ToUpper();

            return $"{formattedStreet}, {formattedCity}, {formattedState} - {zip}";
        }

        
        public string ques12(string name, string orderNo, string address, string deliveryDate)
        {
            return $"Dear {name},\n\n" +
                   $"Thank you for your order!\n" +
                   $"Order Number: {orderNo}\n" +
                   $"Delivery Address: {address}\n" +
                   $"Expected Delivery Date: {deliveryDate}\n\n" +
                   "Regards,\nCourier Team";
        }

        
        public double ques13(string source, string destination, double weight)
        {
            Console.Write("Enter distance in kilometers: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            double cost = (distance * 5) + (weight * 10);

            Console.WriteLine($"\nShipping from {source} to {destination} will cost {cost}");

            return cost;

        }


        public string ques14(int length = 12)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "@#$%!&*";

            string allChars = upper + lower + digits + special;
            Random rnd = new Random();
            StringBuilder password = new StringBuilder();

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

     
        public List<string> ques15(List<string> addresses, string query)
        {
            List<string> result = new List<string>();

            foreach (var addr in addresses)
            {
                if (addr.ToLower().Contains(query.ToLower()))
                {
                    result.Add(addr);
                }
            }

            return result;
        }

        public void RunDemo()
        {
            while (true)
            {
                
                
                Console.WriteLine("9  - Parcel Tracking");
                Console.WriteLine("10 - Customer Data Validation");
                Console.WriteLine("11 - Address Formatting");
                Console.WriteLine("12 - Order Confirmation Email");
                Console.WriteLine("13 - Calculate Shipping Cost");
                Console.WriteLine("14 - Password Generator");
                Console.WriteLine("15 - Find Similar Addresses");
                Console.WriteLine("0  - Exit");
                Console.Write("Enter your choice (0–15): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Exiting demo. Thank you!");
                        return;

                    case "9":
                        Console.Write("Enter tracking number: ");
                        string trackNo = Console.ReadLine();
                        Console.WriteLine(ques9(trackNo));
                        break;

                    case "10":
                        Console.Write("Enter detail type (name/address/phone): ");
                        string detail = Console.ReadLine();
                        Console.Write("Enter data to validate: ");
                        string data = Console.ReadLine();
                        Console.WriteLine(ques10(data, detail) ? "Valid" : "Invalid");
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
                        Console.WriteLine("Formatted Address: " + ques11(street, city, state, zip));
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
                        Console.WriteLine(ques12(name, orderNo, address, deliveryDate));
                        break;

                    case "13":
                        Console.Write("Enter Source Location: ");
                        string source = Console.ReadLine();
                        Console.Write("Enter Destination Location: ");
                        string destination = Console.ReadLine();
                        Console.Write("Enter Parcel Weight (kg): ");
                        if (double.TryParse(Console.ReadLine(), out double weight))
                        {
                            Console.WriteLine("Shipping Cost: ₹" + ques13(source, destination, weight));
                        }
                        else
                        {
                            Console.WriteLine("Invalid weight input.");
                        }
                        break;

                    case "14":
                        Console.Write("Enter Password Length: ");
                        if (int.TryParse(Console.ReadLine(), out int length))
                        {
                            Console.WriteLine("Generated Password: " + ques14(length));
                        }
                        else
                        {
                            Console.WriteLine("Invalid length input.");
                        }
                        break;

                    case "15":
                        List<string> addresses = new List<string>
                {
                    "123 Main Street",
                    "45 Rose Avenue",
                    "123 Main St",
                    "678 Main Road",
                    "Rose Garden Block B"
                };

                        Console.Write("Enter address keyword to search: ");
                        string keyword = Console.ReadLine();
                        List<string> similar = ques15(addresses, keyword);
                        Console.WriteLine($"Similar addresses to '{keyword}':");
                        foreach (string addr in similar)
                        {
                            Console.WriteLine("- " + addr);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 0–15.");
                        break;
                }
            }
        }

    }

}

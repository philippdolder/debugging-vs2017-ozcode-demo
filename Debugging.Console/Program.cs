using System;
using System.Text;

namespace Debugging
{
    // Attach
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            Console.WriteLine();

            var repository = new CustomerRepository();
            var customers = repository.GetCustomers();

            foreach (var customer in customers)
            {
                Print(customer);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Print(Customer customer)
        {
            var output = new StringBuilder();

            output.AppendLine($"Customer = {customer.Name}; Locations = {customer.Locations.Count}");

            foreach (var location in customer.Locations)
            {
                output.AppendLine(Print(location));
            }

            output.AppendLine("---");

            Console.Write(output.ToString());
        }

        private static string Print(Location location)
        {
            var address = location.Address;
            return $"Location = {location.Name}; Address = {address.Street}; {address.PostalCode} {address.City}";
        }
    }
}

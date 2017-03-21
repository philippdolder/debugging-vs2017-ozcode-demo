using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Debugging
{
    public class Breakpoints
    {
        private readonly IReadOnlyCollection<Customer> customers;

        public Breakpoints()
        {
            this.customers = new CustomerRepository().GetCustomers();
        }

        [Fact]
        public void ConditionalBreakpoint()
        {
            foreach (var customer in this.customers)
            {
                var primaryAddress = customer.PrimaryLocation.Address;
            }
        }

        [Fact]
        public void WhenChangedBreakpoint()
        {
            foreach (var customer in this.customers)
            {
                foreach (var location in customer.Locations)
                {
                    var terminals = location.Terminals.Count;
                }
            }

        }

        [Fact]
        public void WhenSetBreak()
        {
            var city = GetCity(this.customers.First().PrimaryLocation);

            city.Should().Be("Zofingen");
        }

        private static string GetCity(Location location)
        {
            location.Address.City = "Genf";

            return location.Address.City;
        }
    }
}
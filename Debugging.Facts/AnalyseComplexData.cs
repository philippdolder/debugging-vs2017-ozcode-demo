using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Debugging
{
    public class AnalyseComplexData
    {
        private readonly IReadOnlyCollection<Customer> customers;

        public AnalyseComplexData()
        {
            this.customers = new CustomerRepository().GetCustomers();
        }

        [Fact]
        public void Compare()
        {
            var migros = this.customers.First();
            var kiosk = this.customers.Last();
        }

        [Fact]
        public void CompareWithinCollection()
        {
            var locations = this.customers.First().Locations;
        }

        [Fact]
        public void CompareWithSnapshot()
        {
            var migros = this.customers.First();

            migros.AddLocation(new Location("Migrolino Tankstelle", new Address {Street = "Tankstelle", PostalCode = "6030", City = "Ebikon"}));
        }

        [Fact]
        public void FilterCollections()
        {
            var customers = this.customers;
        }

        [Fact]
        public void Export()
        {
            var addresses = this.customers.SelectMany(_ => _.Locations).Select(_ => _.Address);
        }

        [Fact]
        public void ExportToExcel()
        {
            var addresses = this.customers.SelectMany(_ => _.Locations).Select(_ => _.Address).ToList();
        }
    }
}
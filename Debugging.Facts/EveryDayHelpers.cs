using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Debugging
{
    public class EveryDayHelpers
    {
        #region boring stuff - don't use regions, except for demos ;-)
        private readonly IReadOnlyCollection<Customer> customers;

        public EveryDayHelpers()
        {
            this.customers = new CustomerRepository().GetCustomers();
        }
        #endregion

        [Fact]
        public void DebuggerDisplay()
        {
            var address = this.customers.First().PrimaryLocation.Address;
        }

        [Fact]
        public void StarProperties()
        {
            var location = this.customers.First().PrimaryLocation;
        }

        [Fact]
        public void CustomExpressions()
        {
            var location = this.customers.First().PrimaryLocation;
            var address = this.customers.First().PrimaryLocation.Address;
        }

        [Fact]
        public void Predict_Hud()
        {
            var customer = new CustomerRepository().GetCustomers().ElementAt(0); // 0, 1, 2

            var numberOfTerminals = customer.Locations.SelectMany(_ => _.Terminals).Count();

            if (numberOfTerminals > 15 || numberOfTerminals == 4)
            {
                SpecialCustomerTreatment();
            }
            else
            {
                NormalCustomerTreatment();
            }
        }

        private static void NormalCustomerTreatment()
        {
        }

        private static void SpecialCustomerTreatment()
        {
        }
    }
}
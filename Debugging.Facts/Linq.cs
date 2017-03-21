using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

// ReSharper disable ReplaceWithSingleCallToCount

namespace Debugging
{
    public class Linq
    {
        #region boring stuff - never use regions except for demos though ;-)
        private readonly IReadOnlyCollection<Customer> customers;

        public Linq()
        {
            var repository = new CustomerRepository();
            this.customers = repository.GetCustomers();
        }
        #endregion

        [Fact]
        public void ListCustomerNames()
        {
            var customerNames = this.customers.Select(_ => _.Name);

            customerNames.Should().HaveCount(4);
        }

        [Fact]
        public void GetStoresInBasel()
        {
            var storesInBasel = this.customers
                .SelectMany(_ => _.Locations)
                .Where(_ => _.Address.City == "Basel")
                .Select(_ => _.Name);

            storesInBasel.Should().HaveCount(3);
        }

        [Fact]
        public void CountNumberOfTerminalsWhereICanPayWithMasterCard()
        {
            var numberOfMasterCardCapableTerminals = this.customers
                .SelectMany(_ => _.Locations)
                .SelectMany(_ => _.Terminals)
                .SelectMany(_ => _.PaymentMethods)
                .Where(_ => _ == PaymentMethod.MasterCard)
                .Count();

            numberOfMasterCardCapableTerminals.Should().Be(37);
        }

        [Fact]
        public void ExceptionInLinqExpression()
        {
            var willThrow = this.customers
                .SelectMany(_ => _.Locations)
                .Where(_ => _.Address.City == "Basel")
                .Select(_ => _.Name[50]);
        }

        [Fact]
        public void ShowStoresWhereICanPayWithPostCard()
        {
            var storesWithPostCard = from customer in this.customers
                from location in customer.Locations
                from terminal in location.Terminals
                from paymentMethod in terminal.PaymentMethods
                where paymentMethod == PaymentMethod.PostCard
                select location.Name;

            storesWithPostCard.Should().HaveCount(2);

//group location by location.Name into uniqueLocation
//select uniqueLocation;
        }
    }
}
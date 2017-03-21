using System.Collections.Generic;

namespace Debugging
{
    public class CustomerBuilder
    {
        private int nextTerminalId;
        private readonly Customer customer;
        private Location currentLocation;

        public CustomerBuilder(string customerName, int firstTerminalId)
        {
            this.nextTerminalId = firstTerminalId;
            this.customer = new Customer(customerName);
        }

        public CustomerBuilder WithLocation(string locationName, Address address)
        {
            this.currentLocation = new Location(locationName, address);
            this.customer.AddLocation(this.currentLocation);

            return this;
        }

        public CustomerBuilder WithTerminals(int numberOfTerminals, string terminalType, IReadOnlyCollection<string> paymentMethods)
        {
            for (int i = 0; i < numberOfTerminals; i++)
            {
                var terminal = new Terminal(this.nextTerminalId++, terminalType);

                foreach (var paymentMethod in paymentMethods)
                {
                    terminal.AddPaymentMethod(paymentMethod);
                }

                this.currentLocation.AddTerminal(terminal);
            }

            return this;
        }

        public Customer Build()
        {
            return this.customer;
        }
    }
}
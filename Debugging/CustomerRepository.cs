using System.Collections.Generic;

namespace Debugging
{
    public class CustomerRepository
    {
        public IReadOnlyCollection<Customer> GetCustomers()
        {
            var migros = new CustomerBuilder("Migros", 1)
                .WithLocation("Migros Zofingen", new Address{Street = "Hauptstrasse 5", PostalCode = "4800", City = "Zofingen"})
                    .WithTerminals(4, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .WithLocation("Migros Luzern", new Address{Street = "Bahnhofstrasse 1", PostalCode = "6000", City = "Luzern"})
                    .WithTerminals(4, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .WithLocation("Migros Basel", new Address{Street = "Bahnhofplatz", PostalCode = "4053", City = "Basel"})
                    .WithTerminals(4, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .WithLocation("Migros Bern", new Address{Street = "Marktgasse 31", PostalCode = "3000", City = "Bern"})
                    .WithTerminals(4, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .Build();

            var coop = new CustomerBuilder("Coop", 101)
                .WithLocation("Coop Basel", new Address{Street = "Güterstrasse 190", PostalCode = "4053", City = "Basel"})
                    .WithTerminals(5, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .WithLocation("Coop Bern", new Address{Street = "Marktgasse 24", PostalCode = "3011", City = "Bern"})
                    .WithTerminals(8, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .Build();

            var aldi = new CustomerBuilder("Aldi", 201)
                .WithLocation("Aldi Luzern", new Address{Street = "Zürichstrasse 21", PostalCode = "6000", City = "Luzern"})
                    .WithTerminals(2, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .WithLocation("Aldi Bern", new Address{Street = "Bärengraben", PostalCode = "3000", City = "Bern"})
                    .WithTerminals(2, TerminalType.CashRegister, PaymentMethod.AllCreditCards)
                .Build();

            var kiosk = new CustomerBuilder("Kiosk", 301)
                .WithLocation("Kiosk Basel", new Address{Street = "Bahnhofplatz", PostalCode = "4053", City = "Basel"})
                    .WithTerminals(2, TerminalType.StandAlone, PaymentMethod.AllCards)
                .WithLocation("Kiosk Zofingen", new Address{Street = "Bahnhofstrasse", PostalCode = "4800", City = "Zofingen"})
                    .WithTerminals(1, TerminalType.StandAlone, PaymentMethod.AllCards)
                    .WithTerminals(1, TerminalType.StandAlone, PaymentMethod.AllCreditCards)
                .Build();

            return new[]
            {
                migros,
                coop,
                aldi,
                kiosk
            };
        }
    }
}
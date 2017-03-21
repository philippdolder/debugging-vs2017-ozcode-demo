using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Debugging
{
    public class Customer
    {
        private readonly List<Location> locations = new List<Location>();

        public string Name { get; }
        public IReadOnlyCollection<Location> Locations => this.locations;
        public Location PrimaryLocation => this.locations.FirstOrDefault();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddLocation(Location location)
        {
            this.locations.Add(location);
        }
    }

    public class Location
    {
        private readonly List<Terminal> terminals = new List<Terminal>();

        public string Name { get; }
        public Address Address { get; }
        public IReadOnlyCollection<Terminal> Terminals => this.terminals;

        public Location(string name, Address address)
        {
            this.Name = name;
            this.Address = address;
        }

        public void AddTerminal(Terminal terminal)
        {
            this.terminals.Add(terminal);
        }
    }

    //[DebuggerDisplay("{this.Street + \";\" + this.PostalCode + this.City}", Name = "Address")]
    public class Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

    public class Terminal
    {
        private readonly List<string> paymentMethods = new List<string>();

        public int TerminalId { get; }
        public string Type { get; }
        public IReadOnlyCollection<string> PaymentMethods => this.paymentMethods;
        public Terminal(int terminalId, string type)
        {
            this.TerminalId = terminalId;
            this.Type = type;
        }

        public void AddPaymentMethod(string paymentMethod)
        {
            this.paymentMethods.Add(paymentMethod);
        }
    }

    public static class TerminalType
    {
        public const string CashRegister = "CashRegister";
        public const string StandAlone = "StandAlone";
        public const string Mobile = "Mobile";
    }

    public static class PaymentMethod
    {
        public const string Visa = "Visa";
        public const string MasterCard = "MasterCard";
        public const string PostCard = "PostCard";

        public static readonly IReadOnlyCollection<string> AllCreditCards = new[] { Visa, MasterCard };
        public static readonly IReadOnlyCollection<string> AllCards = new[] { Visa, MasterCard, PostCard };
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Debugging
{
    public class CSharp7
    {
        [Fact]
        public void Tuples()
        {
            const string Input = "The quick brown fox jumps over the lazy dog.";

            (int numberOfLetters, List<string> words) = EvaluateText(Input);

            numberOfLetters.Should().Be(35);
            words.Should().HaveCount(9);
        }

        [Fact]
        public void Deconstruct()
        {
            const string Input = "The quick brown fox jumps over the lazy dog.";

            (int numberOfLetters, List<string> words) = EvaluateText2(Input);

            numberOfLetters.Should().Be(35);
            words.Should().HaveCount(9);
        }

        private static (int, List<string>) EvaluateText(string input)
        {
            var words = input.Split(new[] {" ", "." }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int sum = words.SelectMany(_ => _).Count();

            return (sum, words);
        }

        private static Result EvaluateText2(string input)
        {
            var words = input.Split(new[] {" ", "." }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int sum = words.SelectMany(_ => _).Count();

            return new Result(sum, words);
        }

        private class Result
        {
            public Result(int sum, List<string> words)
            {
                this.Sum = sum;
                this.Words = words;
            }

            public int Sum { get; }
            public List<string> Words { get; }

            public void Deconstruct(out int sum, out List<string> words)
            {
                sum = this.Sum;
                words = this.Words;
            }
        }

        [Fact]
        public void PatternMatching()
        {
            var terminals = new TerminalBase[] { new StandAloneTerminal(hasPrinter: false), new StandAloneTerminal(hasPrinter: true), new CashRegisteredTerminal(), new MobileTerminal(), null };
            const string Text = "Thanks for your purchase";

            foreach (var terminal in terminals)
            {
                switch (terminal)
                {
                    case StandAloneTerminal t when t.HasPrinter: t.PrintReceipt(Text);
                        break;
                    case StandAloneTerminal t when !t.HasPrinter: t.SendMail(Text);
                        break;
                    case CashRegisteredTerminal t: t.NotifyCashRegister();
                        break;
                    case MobileTerminal t: t.NotifyPhoneApp(Text);
                        break;
                    case null: Console.WriteLine("Terminal is null.");
                        break;
                    default:
                        throw new InvalidOperationException("Terminal type is not supported");
                }
            }
        }

        private class TerminalBase { }
        private class StandAloneTerminal : TerminalBase
        {
            public bool HasPrinter { get; }

            public StandAloneTerminal(bool hasPrinter)
            {
                this.HasPrinter = hasPrinter;
            }

            public void PrintReceipt(string text)
            {
            }

            public void SendMail(string text)
            {
            }
        }

        private class CashRegisteredTerminal : TerminalBase
        {
            public void NotifyCashRegister()
            {
            }
        }

        private class MobileTerminal : TerminalBase
        {
            public void NotifyPhoneApp(string text)
            {
            }
        }
    }
}
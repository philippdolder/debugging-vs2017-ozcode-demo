using System;
using System.Diagnostics;
using System.IO;
using FluentAssertions;
using Xunit;

namespace Debugging
{
    public class Exceptions
    {
        [Fact]
        public void InnerException()
        {
            try
            {
                ThrowException();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("this should not happen", e);
            }
        }

        [Fact]
        public void PredictException()
        {
            Customer customer = CreateCustomer();

            customer.PrimaryLocation.Name.Should().NotBeEmpty();
        }

        [Fact]
        public void ExceptionsAreCollectedInDiagnosticTools()
        {
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    ThrowException();
                }
                catch (Exception)
                {
                    //
                }
            }

            Debugger.Break();
        }

        [Fact]
        public void EnableExceptionForSpecificAssemblies()
        {
            try
            {
                ThrowException();
            }
            catch (Exception)
            {
            }

            try
            {
                ExceptionThrower.Throw();
            }
            catch (Exception)
            {
            }

            Debugger.Break();
        }

        private static Customer CreateCustomer()
        {
            return new Customer("My Customer");
        }

        private static void ThrowException()
        {
            throw new FileNotFoundException("File has not been found");
        }
    }
}
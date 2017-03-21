using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Debugging
{
    public class Profiling
    {

        [Fact]
        public async Task ProfileLongRunningUnitTest()
        {
            var result = await LongRunningAlgorithm();
            var result2 = await MediumRunningAlgorithm();

            result.Should().Be(42);
            result2.Should().Be(21);
        }

        private static async Task<int> LongRunningAlgorithm()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            await Task.Delay(1000).ConfigureAwait(false);
            await Task.Delay(1000).ConfigureAwait(false);
            await Task.Delay(1000).ConfigureAwait(false);

            return 42;
        }

        private static async Task<int> MediumRunningAlgorithm()
        {
            await Task.Delay(200).ConfigureAwait(false);

            return 21;
        }
    }
}
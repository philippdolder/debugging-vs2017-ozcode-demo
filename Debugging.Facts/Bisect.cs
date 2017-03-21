using FluentAssertions;
using Xunit;

namespace Debugging
{
    public class Bisect
    {
        [Fact]
        public void AFeatureThatIsWorking()
        {
            true.Should().BeTrue();
        }
    }
}
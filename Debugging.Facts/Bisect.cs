using FluentAssertions;
using Xunit;

namespace Debugging
{
    public class Bisect
    {
        [Fact]
        public void AFeatureThatIsWorking()
        {
            false.Should().BeTrue();
        }

        [Fact]
        public void AddAnotherFeature()
        {
            1.Should().Be(1);
        }

        [Fact]
        public void MoreFeatures()
        {
            "Hello World".Should().HaveLength(11);
        }
    }
}
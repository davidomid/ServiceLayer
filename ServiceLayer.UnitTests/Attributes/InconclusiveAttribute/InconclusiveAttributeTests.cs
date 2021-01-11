using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.InconclusiveAttribute
{
    public abstract class InconclusiveAttributeTests : UnitTestBase
    {
        protected ServiceLayer.InconclusiveAttribute InconclusiveAttribute;

        protected override void Arrange()
        {
        }

        [Test]
        public void ResultType_Should_Return_Inconclusive()
        {
            InconclusiveAttribute.ResultType.Should().Be(ResultType.Inconclusive);
        }
    }
}

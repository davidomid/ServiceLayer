using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.SuccessAttribute
{
    public abstract class SuccessAttributeTests : UnitTestBase
    {
        protected ServiceLayer.SuccessAttribute SuccessAttribute;

        protected override void Arrange()
        {
        }

        [Test]
        public void ResultType_Should_Return_Success()
        {
            SuccessAttribute.ResultType.Should().Be(ResultType.Success);
        }
    }
}

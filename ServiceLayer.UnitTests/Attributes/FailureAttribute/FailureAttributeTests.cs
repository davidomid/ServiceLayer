using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
{
    public abstract class SuccessAttributeTests : UnitTestBase
    {
        protected ServiceLayer.FailureAttribute FailureAttribute;

        protected override void Arrange()
        {
        }

        [Test]
        public void ResultType_Should_Return_Failure()
        {
            FailureAttribute.ResultType.Should().Be(ResultType.Failure);
        }
    }
}

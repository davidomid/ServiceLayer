using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
{
    public class WhenIsDefaultNotSet : UnitTestBase
    {
        private ServiceLayer.FailureAttribute _failureAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _failureAttribute = new ServiceLayer.FailureAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_False()
        {
            _failureAttribute.IsDefault.Should().BeFalse();
        }
    }
}


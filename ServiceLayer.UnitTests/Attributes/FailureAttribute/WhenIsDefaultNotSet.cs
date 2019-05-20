using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
{
    public class WhenIsDefaultNotSet : UnitTestBase
    {
        private ServiceLayer.Attributes.FailureAttribute _failureAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _failureAttribute = new ServiceLayer.Attributes.FailureAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_False()
        {
            _failureAttribute.IsDefault.Should().BeFalse();
        }
    }
}


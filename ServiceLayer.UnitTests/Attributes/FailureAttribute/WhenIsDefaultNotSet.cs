using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
{
    public class WhenIsDefaultNotSet : SuccessAttributeTests
    {
        protected override void Act()
        {
            FailureAttribute = new ServiceLayer.FailureAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_False()
        {
            FailureAttribute.IsDefault.Should().BeFalse();
        }
    }
}


using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.SuccessAttribute
{
    public class WhenIsDefaultNotSet : SuccessAttributeTests
    {
        protected override void Act()
        {
            SuccessAttribute = new ServiceLayer.SuccessAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            SuccessAttribute.IsDefault.Should().BeFalse();
        }
    }
}


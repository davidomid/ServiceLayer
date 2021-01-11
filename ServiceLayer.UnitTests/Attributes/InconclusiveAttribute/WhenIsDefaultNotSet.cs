using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.InconclusiveAttribute
{
    public class WhenIsDefaultNotSet : InconclusiveAttributeTests
    {
        protected override void Act()
        {
            InconclusiveAttribute = new ServiceLayer.InconclusiveAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            InconclusiveAttribute.IsDefault.Should().BeFalse();
        }
    }
}


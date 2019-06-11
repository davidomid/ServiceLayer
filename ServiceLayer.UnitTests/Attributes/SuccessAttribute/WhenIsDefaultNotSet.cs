using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.SuccessAttribute
{
    public class WhenIsDefaultNotSet : UnitTestBase
    {
        private ServiceLayer.SuccessAttribute _successAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _successAttribute = new ServiceLayer.SuccessAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            _successAttribute.IsDefault.Should().BeFalse();
        }
    }
}


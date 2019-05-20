using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
namespace ServiceLayer.UnitTests.Attributes.SuccessAttribute
{
    public class WhenIsDefaultNotSet : UnitTestBase
    {
        private ServiceLayer.Attributes.SuccessAttribute _successAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _successAttribute = new ServiceLayer.Attributes.SuccessAttribute();
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            _successAttribute.IsDefault.Should().BeFalse();
        }
    }
}


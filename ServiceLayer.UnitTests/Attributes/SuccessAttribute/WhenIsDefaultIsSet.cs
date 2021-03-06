using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.SuccessAttribute
{
    [TestFixtureSource(nameof(Values))]
    public class WhenIsDefaultIsSet : SuccessAttributeTests
    {
        private static readonly bool[] Values = { true, false };

        private readonly bool _value;

        public WhenIsDefaultIsSet(bool value)
        {
            _value = value;
        }

        protected override void Act()
        {
            SuccessAttribute = new ServiceLayer.SuccessAttribute
            {
                IsDefault = _value
            };
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            SuccessAttribute.IsDefault.Should().Be(_value);
        }
    }
}


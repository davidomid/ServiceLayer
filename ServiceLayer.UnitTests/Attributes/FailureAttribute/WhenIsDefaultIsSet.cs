using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
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
            FailureAttribute = new ServiceLayer.FailureAttribute
            {
                IsDefault = _value
            };
        }

        [Test]
        public void IsDefault_Should_Return_False()
        {
            FailureAttribute.IsDefault.Should().Be(_value);
        }
    }
}


using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.UnitTests.Attributes.FailureAttribute
{
    [TestFixtureSource(nameof(Values))]
    public class WhenIsDefaultIsSet : UnitTestBase
    {
        private ServiceLayer.Attributes.FailureAttribute _failureAttribute;

        private static readonly bool[] Values = { true, false };

        private readonly bool _value;

        public WhenIsDefaultIsSet(bool value)
        {
            _value = value;
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _failureAttribute = new ServiceLayer.Attributes.FailureAttribute
            {
                IsDefault = _value
            };
        }

        [Test]
        public void IsDefault_Should_Return_False()
        {
            _failureAttribute.IsDefault.Should().Be(_value);
        }
    }
}

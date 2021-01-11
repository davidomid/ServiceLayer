using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Attributes.InconclusiveAttribute
{
    [TestFixtureSource(nameof(Values))]
    public class WhenIsDefaultIsSet : InconclusiveAttributeTests
    {
        private static readonly bool[] Values = { true, false };

        private readonly bool _value;

        public WhenIsDefaultIsSet(bool value)
        {
            _value = value;
        }

        protected override void Act()
        {
            InconclusiveAttribute = new ServiceLayer.InconclusiveAttribute
            {
                IsDefault = _value
            };
        }

        [Test]
        public void IsDefault_Should_Return_Given_Value()
        {
            InconclusiveAttribute.IsDefault.Should().Be(_value);
        }
    }
}


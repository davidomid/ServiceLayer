using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToServiceResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultTypesEnumValue : UnitTestBase
    {
        private readonly ServiceResultTypes _expectedServiceResultType;
        private ServiceResultTypes _actualServiceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenServiceResultTypesEnumValue(ServiceResultTypes serviceResultType)
        {
            _expectedServiceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_Same_ServiceResultType_As_Given_ServiceResultType()
        {
            _actualServiceResultType.Should().Be(_expectedServiceResultType);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _actualServiceResultType = _expectedServiceResultType.ToServiceResultType();
        }
    }
}

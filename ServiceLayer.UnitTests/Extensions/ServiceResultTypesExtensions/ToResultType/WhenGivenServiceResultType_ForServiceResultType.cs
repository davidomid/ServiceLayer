using System;
using System.Runtime.Serialization;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultType_ForServiceResultType : UnitTestBase
    {
        private readonly ServiceResultTypes _serviceResultType;
        private ServiceResultTypes _resultServiceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenServiceResultType_ForServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_Same_ServiceResultType()
        {
            _resultServiceResultType.Should().Be(_serviceResultType);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _resultServiceResultType = _serviceResultType.ToResultType<ServiceResultTypes>();
        }
    }
}

using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.UnitTests;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ServiceResultTypes _serviceResultType;

        private ServiceLayer.ServiceResult _actualServiceResult;

        private ServiceLayer.ServiceResult _expectedServiceResult;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public From_ServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualServiceResult.Should().Be(_expectedServiceResult);
        }

        protected override void Arrange()
        {
            _expectedServiceResult = MockServiceResultFactory.Object.Create(_serviceResultType);
        }

        protected override void Act()
        {
            _actualServiceResult = _serviceResultType;
        }
    }
}

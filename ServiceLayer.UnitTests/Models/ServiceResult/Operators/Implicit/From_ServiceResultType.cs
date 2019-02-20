using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ServiceResultTypes _serviceResultType;

        private ServiceLayer.ServiceResult _serviceResult;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public From_ServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_Same_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_Null_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _serviceResult = _serviceResultType;
        }
    }
}

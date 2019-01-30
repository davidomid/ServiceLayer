using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private ServiceLayer.ServiceResult _serviceResult;
        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_No_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeEmpty(); 
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _serviceResult = new ServiceLayer.ServiceResult(_serviceResultType);
        }
    }
}
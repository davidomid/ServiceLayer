using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultTypeAndErrorDetails : UnitTestBase
    {
        private ServiceLayer.ServiceResult _serviceResult;
        private string[] _errorDetails;
        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenResultTypeAndErrorDetails(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = new ServiceLayer.ServiceResult(_serviceResultType, _errorDetails);
        }
    }
}
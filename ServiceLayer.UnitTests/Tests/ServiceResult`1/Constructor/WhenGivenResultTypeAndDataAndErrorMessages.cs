using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultTypeAndDataAndErrorMessages : NUnitTestBase
    {
        private ServiceResult<string> _serviceResult;
        private const string TestData = "test data"; 
        private string[] _errorMessages;
        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenResultTypeAndDataAndErrorMessages(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _serviceResult.Data.Should().Be(TestData);
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = new TestServiceResult<string>(_serviceResultType, TestData, _errorMessages);
        }
    }
}

using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Tests.Create
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultTypeAndDataAndErrorMessages : UnitTestBase
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
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ServiceResult_Of_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Return_ServiceResult_With_Given_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        [Test]
        public void Should_Return_ServiceResult_With_Data_Matching_Given_Data()
        {
            _serviceResult.Data.Should().Be(TestData);
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = ServiceResult<string>.Create(_serviceResultType, TestData, _errorMessages);
        }
    }
}

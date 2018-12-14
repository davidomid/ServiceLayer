using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestData;

namespace ServiceLayer.UnitTests.Models.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndResultTypeAndErrorMessages : UnitTestBase
    {
        private DataServiceResult<TestModel, ServiceResultTypes> _serviceResult;
        private string[] _errorMessages;
        private readonly ServiceResultTypes _serviceResultType;
        private TestModel _testData;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenDataAndResultTypeAndErrorMessages(ServiceResultTypes serviceResultType)
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
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        protected override void Arrange()
        {
            _testData = new TestModel();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = new DataServiceResult<TestModel, ServiceResultTypes>(_testData, _serviceResultType, _errorMessages);
        }
    }
}

using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndResultType : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private DataServiceResult<TestData> _serviceResult;
        private readonly ServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenDataAndResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Have_Equivalent_ErrorMessages()
        {
            _serviceResult.ErrorDetails.Should().BeEquivalentTo(_errorMessages);
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult(_testData, _serviceResultType, _errorMessages);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}


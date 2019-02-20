using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;
        private readonly TestCustomServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultType(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Have_Equivalent_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeEquivalentTo(_errorDetails);
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
            _serviceResult = _service.DataResult(_testData, _serviceResultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}


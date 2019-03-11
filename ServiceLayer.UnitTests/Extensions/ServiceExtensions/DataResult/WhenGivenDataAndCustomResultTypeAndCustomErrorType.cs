using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Internal.Factories;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndCustomErrorType : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, string[]> _serviceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, string[]> _expectedServiceResult;

        private readonly TestCustomServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();
        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultTypeAndCustomErrorType(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().Be(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult(_testData, _serviceResultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedServiceResult =
                MockDataServiceResultFactory.Object.Create(_testData, _serviceResultType, _errorDetails);
        }
    }
}


using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndErrorObjectArray : UnitTestBase
    {
        private IService _service;
        private object[] _errorDetails;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _expectedServiceResult;

        private readonly TestCustomServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();
        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultTypeAndErrorObjectArray(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult(_testData, _serviceResultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), 123, new object() };
            _expectedServiceResult =
                MockDataServiceResultFactory.Object.Create(_testData, _serviceResultType, _errorDetails);
        }
    }
}


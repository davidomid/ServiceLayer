using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    public class WhenGivenDataAndGenericResultTypeArgumentAndGenericErrorTypeArgument : UnitTestBase
    {
        private IService _service;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _serviceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedServiceResult; 

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(_testData);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_testData);
        }
    }
}


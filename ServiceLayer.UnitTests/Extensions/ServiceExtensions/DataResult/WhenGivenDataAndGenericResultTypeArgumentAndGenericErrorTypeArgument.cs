using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    public class WhenGivenDataAndGenericResultTypeArgumentAndGenericErrorTypeArgument : UnitTestBase
    {
        private IService _service;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _result;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _expectedResult; 

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().BeSameAs(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.DataResult<TestData, TestCustomResultType, TestErrorType>(_testData);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockDataResultFactory.Object.Create<TestData, TestCustomResultType, TestErrorType>(_testData);
        }
    }
}


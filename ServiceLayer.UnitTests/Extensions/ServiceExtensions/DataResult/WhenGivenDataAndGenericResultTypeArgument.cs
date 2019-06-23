using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    public class WhenGivenDataAndGenericResultTypeArgument : UnitTestBase
    {
        private IService _service;
        private DataResult<TestData, TestCustomServiceResultTypes> _result;
        private DataResult<TestData, TestCustomServiceResultTypes> _expectedResult; 

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().BeSameAs(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.DataResult<TestData, TestCustomServiceResultTypes>(_testData);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes>(_testData);
        }
    }
}


using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Success
{
    public class WhenGivenData : UnitTestBase
    {
        private IService _service;
        private readonly TestData _testData = new TestData(); 
        private SuccessResult<TestData> _successResult;
        private SuccessResult<TestData> _expectedResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _successResult.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _successResult = _service.Success(_testData); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockSuccessResultFactory.Object.Create(_testData);
        }
    }
}

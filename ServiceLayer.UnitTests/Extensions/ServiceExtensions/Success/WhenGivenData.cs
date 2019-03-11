using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Success
{
    public class WhenGivenData : UnitTestBase
    {
        private IService _service;
        private const string TestData = "test data"; 
        private SuccessResult<string> _successResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _successResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_SuccessResult_With_Data_Matching_Given_Data()
        {
            _successResult.Data.Should().Be(TestData);
        }

        protected override void Act()
        {
            _successResult = _service.Success(TestData); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
        }
    }
}

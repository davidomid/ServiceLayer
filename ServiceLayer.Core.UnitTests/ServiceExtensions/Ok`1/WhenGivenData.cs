using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions
{
    public class WhenGivenData : UnitTestBase
    {
        private IService _service;
        private const string TestData = "test data"; 
        private OkResult<string> _okResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _okResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_OkResult_With_Data_Matching_Given_Data()
        {
            _okResult.Data.Should().Be(TestData);
        }

        protected override void Act()
        {
            _okResult = _service.Ok(TestData); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
        }
    }
}

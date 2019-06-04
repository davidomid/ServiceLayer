using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests
{
    public class WhenErrorDetails : UnitTestBase
    {
        private OkResult<string> _okResult;

        private const string TestData = "test data"; 

        [Test]
        public void Should_Have_Ok_ResultType()
        {
            _okResult.ResultType.Should().Be(HttpServiceResultTypes.Ok);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _okResult.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_Data_Matching_Given_Data()
        {
            _okResult.Data.Should().Be(TestData);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _okResult = new OkResult<string>(TestData);
        }
    }
}

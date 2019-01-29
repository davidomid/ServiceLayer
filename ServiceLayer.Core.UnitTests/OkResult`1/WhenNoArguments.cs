using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests
{
    public class WhenErrorMessages : UnitTestBase
    {
        private OkResult<string> _okResult;

        private const string TestData = "test data"; 

        [Test]
        public void Should_Have_Ok_ResultType()
        {
            _okResult.ResultType.Should().Be(HttpServiceResultTypes.Ok);
        }

        [Test]
        public void Should_Have_Empty_ErrorMessages()
        {
            _okResult.ErrorMessages.Should().BeEmpty();
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

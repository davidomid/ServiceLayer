using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests.OkResult
{
    public class WhenNoArguments : UnitTestBase
    {
        private Core.OkResult _okResult;

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

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _okResult = new Core.OkResult();
        }
    }
}

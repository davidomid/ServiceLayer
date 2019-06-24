using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult
{
    public class WhenResultIsSuccessful : UnitTestBase
    {
        private IResult _result;

        private IActionResult _actionResult;

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();
            Mock<IResult> mockServiceResult = new Mock<IResult>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(true);
            _result = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _actionResultFactory.Create(_result);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _actionResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_OkResult()
        {
            _actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkResult>(); 
        }
    }
}

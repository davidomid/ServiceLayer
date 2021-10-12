using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult
{
    public class WhenResultIsNotSuccessful : UnitTestBase
    {
        private IResult _result;

        private IActionResult _actionResult;

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory(new AspNetCorePluginSettings());
            Mock<IResult> mockResult = new Mock<IResult>();
            mockResult.SetupGet(r => r.IsSuccessful).Returns(false);
            _result = mockResult.Object;
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
        public void Should_Return_ObjectResult()
        {
            _actionResult.Should().BeOfType<ObjectResult>();
        }

        [Test]
        public void Should_Have_500_StatusCode()
        {
            ObjectResult objectResult = (ObjectResult)_actionResult;
            objectResult.StatusCode.Should().Be(500);
        }
    }
}

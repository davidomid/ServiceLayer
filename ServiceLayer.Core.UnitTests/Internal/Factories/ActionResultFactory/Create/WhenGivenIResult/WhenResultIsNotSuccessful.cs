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

        private readonly object _errorDetails = new object();

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();
            Mock<IResult> mockServiceResult = new Mock<IResult>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(false);
            mockServiceResult.SetupGet(r => r.ErrorDetails).Returns(_errorDetails);
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
        public void Should_Return_ObjectResult()
        {
            _actionResult.Should().BeOfType<ObjectResult>();
        }

        [Test]
        public void Should_Have_Value_Matching_Given_ErrorDetails()
        {
            ObjectResult objectResult = (ObjectResult)_actionResult;
            objectResult.Value.Should().Be(_errorDetails);
        }

        [Test]
        public void Should_Have_500_StatusCode()
        {
            ObjectResult objectResult = (ObjectResult)_actionResult;
            objectResult.StatusCode.Should().Be(500);
        }
    }
}

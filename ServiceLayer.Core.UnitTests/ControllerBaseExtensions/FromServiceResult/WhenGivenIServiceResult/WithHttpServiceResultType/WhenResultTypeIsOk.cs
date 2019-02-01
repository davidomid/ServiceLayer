using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsOk : UnitTestBase
    {
        private IServiceResult<HttpServiceResultTypes> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        protected override void Arrange()
        {
            _controller = new TestController();
            Mock<IServiceResult<HttpServiceResultTypes>> mockServiceResult = new Mock<IServiceResult<HttpServiceResultTypes>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(HttpServiceResultTypes.Ok);

            mockServiceResult.Verify();
            _dataServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _controller.FromServiceResult(_dataServiceResult);
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

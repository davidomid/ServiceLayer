using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult
{
    public class WhenResultIsSuccessful : UnitTestBase
    {
        private IDataServiceResult<string> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        protected override void Arrange()
        {
            _controller = new TestController();
            Mock<IDataServiceResult<string>> mockServiceResult = new Mock<IDataServiceResult<string>>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(true);
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
        public void Should_Return_OkObjectResult()
        {
            _actionResult.Should().BeOfType<OkObjectResult>(); 
        }
    }
}

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsOk : UnitTestBase
    {
        private IDataServiceResult<string, HttpServiceResultTypes> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        protected override void Arrange()
        {
            _controller = new TestController();
            Mock<IDataServiceResult<string, HttpServiceResultTypes>> mockServiceResult = new Mock<IDataServiceResult<string, HttpServiceResultTypes>>();
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
        public void Should_Return_OkObjectResult()
        {
            _actionResult.Should().BeOfType<OkObjectResult>(); 
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            OkObjectResult okObjectResult = (OkObjectResult) _actionResult;
            okObjectResult.Value.Should().Be(_dataServiceResult.Data);
        }
    }
}

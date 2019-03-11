using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsBadRequest : UnitTestBase
    {
        private IServiceResult<HttpServiceResultTypes> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        private string[] _errorDetails;

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _controller = new TestController();
            Mock<IServiceResult<HttpServiceResultTypes>> mockServiceResult = new Mock<IServiceResult<HttpServiceResultTypes>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(HttpServiceResultTypes.BadRequest);
            mockServiceResult.SetupGet(r => r.ErrorDetails).Returns(_errorDetails);
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
        public void Should_Return_BadRequestResult()
        {
            _actionResult.Should().BeOfType<BadRequestObjectResult>(); 
        }

        [Test]
        public void Should_Have_Value_Matching_Given_ErrorDetails()
        {
            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)_actionResult;
            badRequestObjectResult.Value.Should().Be(_errorDetails);
        }
       
    }
}

using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIServiceResultInstance
{
    public class WhenResultIsNotSuccessful : UnitTestBase
    {
        private IServiceResult _serviceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        private string[] _errorMessages;

        protected override void Arrange()
        {
            _controller = new TestController();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            Mock<IServiceResult> mockServiceResult = new Mock<IServiceResult>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(false);
            mockServiceResult.SetupGet(r => r.ErrorMessages).Returns(_errorMessages);
            _serviceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _controller.FromServiceResult(_serviceResult);
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
        public void Should_Have_Value_Matching_Given_ErrorMessages()
        {
            ObjectResult objectResult = (ObjectResult)_actionResult;
            objectResult.Value.Should().Be(_errorMessages);
        }

        [Test]
        public void Should_Have_500_StatusCode()
        {
            ObjectResult objectResult = (ObjectResult)_actionResult;
            objectResult.StatusCode.Should().Be(500);
        }
    }
}

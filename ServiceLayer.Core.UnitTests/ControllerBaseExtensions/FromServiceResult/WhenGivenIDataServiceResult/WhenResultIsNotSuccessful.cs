using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIDataServiceResult
{
    public class WhenResultIsNotSuccessful : UnitTestBase
    {
        private IDataServiceResult<string> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        private string[] _errorDetails;

        protected override void Arrange()
        {
            _controller = new TestController();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            Mock<IDataServiceResult<string>> mockServiceResult = new Mock<IDataServiceResult<string>>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(false);
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

using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsNotFound : UnitTestBase
    {
        private IDataServiceResult<string, HttpServiceResultTypes> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        private string[] _errorDetails;

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _controller = new TestController();
            Mock<IDataServiceResult<string, HttpServiceResultTypes>> mockServiceResult = new Mock<IDataServiceResult<string, HttpServiceResultTypes>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(HttpServiceResultTypes.NotFound);
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
        public void Should_Return_NotFoundResult()
        {
            _actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundResult>(); 
        }
       
    }
}

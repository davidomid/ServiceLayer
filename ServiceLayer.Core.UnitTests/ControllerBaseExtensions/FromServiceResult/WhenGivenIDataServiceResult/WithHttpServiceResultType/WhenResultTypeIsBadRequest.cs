﻿using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsBadRequest : UnitTestBase
    {
        private IDataServiceResult<string, HttpServiceResultTypes> _dataServiceResult;

        private IActionResult _actionResult;

        private TestController _controller;

        private string[] _errorMessages;

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _controller = new TestController();
            Mock<IDataServiceResult<string, HttpServiceResultTypes>> mockServiceResult = new Mock<IDataServiceResult<string, HttpServiceResultTypes>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(HttpServiceResultTypes.BadRequest);
            mockServiceResult.SetupGet(r => r.ErrorMessages).Returns(_errorMessages);
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
        public void Should_Have_Value_Matching_Given_ErrorMessages()
        {
            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)_actionResult;
            badRequestObjectResult.Value.Should().Be(_errorMessages);
        }
       
    }
}
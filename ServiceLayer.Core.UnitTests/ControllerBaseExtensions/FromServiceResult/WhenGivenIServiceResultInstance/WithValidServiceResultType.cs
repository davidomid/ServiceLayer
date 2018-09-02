using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIServiceResultInstance
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WithValidServiceResultType : NUnitTestBase
    {
        private IServiceResult _existingServiceResult;

        private IActionResult _actionResult;

        private readonly ServiceResultTypes _serviceResultType;

        private TestController _controller;

        public WithValidServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        protected override void Arrange()
        {
            _controller = new TestController();
            Mock<IServiceResult> mockServiceResult = new Mock<IServiceResult>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(_serviceResultType);
            _existingServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _controller.FromServiceResult(_existingServiceResult);
        }

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        [Test]
        public void Should_Not_Return_Null()
        {
            _actionResult.Should().NotBeNull();
        }
    }
}

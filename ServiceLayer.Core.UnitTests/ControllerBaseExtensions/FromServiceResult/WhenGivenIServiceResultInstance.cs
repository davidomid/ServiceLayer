using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenIServiceResultInstance : NUnitTestBase
    {
        private IServiceResult _existingServiceResult;

        private IActionResult _actionResult;

        private readonly ServiceResultTypes _serviceResultType;

        private TestController _controller;

        public WhenGivenIServiceResultInstance(ServiceResultTypes serviceResultType)
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
            TestController controller = new TestController();
            _actionResult = controller.FromServiceResult(_existingServiceResult);
        }

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        [Test]
        public void Should_Not_Return_Null()
        {
            _actionResult.Should().NotBeNull();
        }
    }
}

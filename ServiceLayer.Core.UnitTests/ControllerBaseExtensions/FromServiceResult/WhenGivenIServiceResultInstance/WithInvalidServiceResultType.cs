using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.Core.UnitTests.ControllerBaseExtensions.FromServiceResult.WhenGivenIServiceResultInstance
{
    public class WithInvalidServiceResultType : NUnitTestBase
    {
        private IServiceResult _existingServiceResult;

        private  ServiceResultTypes _serviceResultType;

        private TestController _controller;

        private Exception _exception; 

        protected override void Arrange()
        {
            _controller = new TestController();
            _serviceResultType = (ServiceResultTypes)9999;
            Mock<IServiceResult> mockServiceResult = new Mock<IServiceResult>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(_serviceResultType);
            _existingServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            Action action = () => _controller.FromServiceResult(_existingServiceResult);
            _exception = action.Should().Throw<Exception>().Which;
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException()
        {
            _exception.Should().BeOfType<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Should_Throw_Exception_With_Expected_Message()
        {
            _exception.Message
                .Should().StartWith(
                    $"No action result could be returned for service result type {_serviceResultType}")
                .And.EndWith($"Parameter name: {nameof(_existingServiceResult.ResultType)}"); 
        }

    }
}

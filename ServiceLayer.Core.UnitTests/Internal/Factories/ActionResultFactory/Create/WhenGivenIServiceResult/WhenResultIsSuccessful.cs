using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIServiceResult
{
    public class WhenResultIsSuccessful : UnitTestBase
    {
        private IServiceResult _serviceResult;

        private IActionResult _actionResult;

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();
            Mock<IServiceResult> mockServiceResult = new Mock<IServiceResult>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(true);
            _serviceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _actionResultFactory.Create(_serviceResult);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _actionResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_OkResult()
        {
            _actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkResult>(); 
        }
    }
}

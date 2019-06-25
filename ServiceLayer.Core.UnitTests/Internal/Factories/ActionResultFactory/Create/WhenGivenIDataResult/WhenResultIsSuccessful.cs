using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataResult
{
    public class WhenResultIsSuccessful : UnitTestBase
    {
        private IDataResult<string> _dataResult;

        private IActionResult _actionResult;

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            ServiceLayerConfig.Plugins.Install(new AspNetCorePlugin());
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();
            Mock<IDataResult<string>> mockResult = new Mock<IDataResult<string>>();
            mockResult.SetupGet(r => r.ResultType).Returns(ResultType.Success);
            _dataResult = mockResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _actionResultFactory.Create(_dataResult);
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
    }
}

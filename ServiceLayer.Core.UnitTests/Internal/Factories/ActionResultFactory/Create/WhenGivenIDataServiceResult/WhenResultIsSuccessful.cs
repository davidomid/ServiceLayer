using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult
{
    public class WhenResultIsSuccessful : UnitTestBase
    {
        private IDataServiceResult<string> _dataServiceResult;

        private IActionResult _actionResult;

        private Core.Internal.Factories.ActionResultFactory _actionResultFactory;

        protected override void Arrange()
        {
            _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();
            Mock<IDataServiceResult<string>> mockServiceResult = new Mock<IDataServiceResult<string>>();
            mockServiceResult.SetupGet(r => r.IsSuccessful).Returns(true);
            _dataServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            _actionResult = _actionResultFactory.Create(_dataServiceResult);
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

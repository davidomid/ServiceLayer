using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIServiceResult.WithHttpServiceResultType
{
    public abstract class GivenAnHttpServiceResultType : UnitTestBase
    {
        private readonly HttpServiceResultTypes _httpServiceResultType;
        protected readonly object ErrorDetails = new object();

        private IServiceResult<HttpServiceResultTypes> _httpServiceResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpServiceResultType(HttpServiceResultTypes httpServiceResultType)
        {
            _httpServiceResultType = httpServiceResultType;
        }

        protected override void Arrange()
        {
            Mock<IServiceResult<HttpServiceResultTypes>> mockServiceResult = new Mock<IServiceResult<HttpServiceResultTypes>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(_httpServiceResultType);
            mockServiceResult.SetupGet(r => r.ErrorDetails).Returns(ErrorDetails);
            _httpServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            ActionResult = _actionResultFactory.Create(_httpServiceResult);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            ActionResult.Should().NotBeNull();
        }
    }
}

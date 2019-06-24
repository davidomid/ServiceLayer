using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public abstract class GivenAnHttpServiceResultType : UnitTestBase
    {
        private readonly HttpStatusCode _httpServiceResultType;
        protected readonly object ErrorDetails = new object();

        private IResult<HttpStatusCode> _httpResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpServiceResultType(HttpStatusCode httpServiceResultType)
        {
            _httpServiceResultType = httpServiceResultType;
        }

        protected override void Arrange()
        {
            Mock<IResult<HttpStatusCode>> mockServiceResult = new Mock<IResult<HttpStatusCode>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(_httpServiceResultType);
            mockServiceResult.SetupGet(r => r.ErrorDetails).Returns(ErrorDetails);
            _httpResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            ActionResult = _actionResultFactory.Create(_httpResult);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            ActionResult.Should().NotBeNull();
        }
    }
}

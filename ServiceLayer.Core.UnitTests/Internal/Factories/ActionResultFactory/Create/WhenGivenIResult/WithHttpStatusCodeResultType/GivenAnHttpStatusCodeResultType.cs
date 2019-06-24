using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public abstract class GivenAnHttpStatusCodeResultType : UnitTestBase
    {
        private readonly HttpStatusCode _httpStatusCode;
        protected readonly object ErrorDetails = new object();

        private IResult<HttpStatusCode> _httpResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpStatusCodeResultType(HttpStatusCode httpResultType)
        {
            _httpStatusCode = httpResultType;
        }

        protected override void Arrange()
        {
            Mock<IResult<HttpStatusCode>> mockResult = new Mock<IResult<HttpStatusCode>>();
            mockResult.SetupGet(r => r.ResultType).Returns(_httpStatusCode);
            mockResult.SetupGet(r => r.ErrorDetails).Returns(ErrorDetails);
            _httpResult = mockResult.Object;
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

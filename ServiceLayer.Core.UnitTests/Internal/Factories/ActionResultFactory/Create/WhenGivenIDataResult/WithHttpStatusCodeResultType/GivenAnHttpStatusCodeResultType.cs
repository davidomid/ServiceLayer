using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataResult.WithHttpStatusCodeResultType
{
    public abstract class GivenAnHttpStatusCodeResultType : UnitTestBase
    {
        private readonly HttpStatusCode _httpStatusCode;
        protected readonly object ErrorDetails = new object();
        protected readonly TestData Data = new TestData();
        private IDataResult<TestData, HttpStatusCode> _httpDataResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpStatusCodeResultType(HttpStatusCode httpResultType)
        {
            _httpStatusCode = httpResultType;
        }

        protected override void Arrange()
        {
            Mock<IDataResult<TestData, HttpStatusCode>> mockResult = new Mock<IDataResult<TestData, HttpStatusCode>>();
            mockResult.SetupGet(r => r.ResultType).Returns(_httpStatusCode);
            mockResult.SetupGet(r => r.Data).Returns(Data);
            _httpDataResult = mockResult.Object;
        }

        protected override void Act()
        {
            ActionResult = _actionResultFactory.Create(_httpDataResult);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            ActionResult.Should().NotBeNull();
        }
    }
}

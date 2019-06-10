using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpStatusCodeResultType
{
    public abstract class GivenAnHttpServiceResultType : UnitTestBase
    {
        private readonly HttpStatusCode _httpServiceResultType;
        protected readonly object ErrorDetails = new object();
        protected readonly TestData Data = new TestData();
        private IDataServiceResult<TestData, HttpStatusCode> _httpDataServiceResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpServiceResultType(HttpStatusCode httpServiceResultType)
        {
            _httpServiceResultType = httpServiceResultType;
        }

        protected override void Arrange()
        {
            Mock<IDataServiceResult<TestData, HttpStatusCode>> mockServiceResult = new Mock<IDataServiceResult<TestData, HttpStatusCode>>();
            mockServiceResult.SetupGet(r => r.ResultType).Returns(_httpServiceResultType);
            mockServiceResult.SetupGet(r => r.ErrorDetails).Returns(ErrorDetails);
            mockServiceResult.SetupGet(r => r.Data).Returns(Data);
            _httpDataServiceResult = mockServiceResult.Object;
        }

        protected override void Act()
        {
            ActionResult = _actionResultFactory.Create(_httpDataServiceResult);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            ActionResult.Should().NotBeNull();
        }
    }
}

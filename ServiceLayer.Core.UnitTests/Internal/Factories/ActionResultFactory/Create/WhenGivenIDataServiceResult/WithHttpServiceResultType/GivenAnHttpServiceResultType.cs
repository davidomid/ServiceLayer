using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public abstract class GivenAnHttpServiceResultType : UnitTestBase
    {
        private readonly HttpServiceResultTypes _httpServiceResultType;
        protected readonly object ErrorDetails = new object();
        protected readonly TestData Data = new TestData();
        private IDataServiceResult<TestData, HttpServiceResultTypes> _httpDataServiceResult;

        protected IActionResult ActionResult;

        private readonly Core.Internal.Factories.ActionResultFactory _actionResultFactory = new Core.Internal.Factories.ActionResultFactory();

        protected GivenAnHttpServiceResultType(HttpServiceResultTypes httpServiceResultType)
        {
            _httpServiceResultType = httpServiceResultType;
        }

        protected override void Arrange()
        {
            Mock<IDataServiceResult<TestData, HttpServiceResultTypes>> mockServiceResult = new Mock<IDataServiceResult<TestData, HttpServiceResultTypes>>();
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

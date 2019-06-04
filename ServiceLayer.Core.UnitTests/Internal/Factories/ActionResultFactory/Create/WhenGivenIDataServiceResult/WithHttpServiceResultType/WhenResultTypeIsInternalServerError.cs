using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsInternalServerError : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsInternalServerError() : base(HttpServiceResultTypes.InternalServerError)
        {
        }

        [Test]
        public void Should_Return_ObjectResult()
        {
            ActionResult.Should().BeOfType<ObjectResult>(); 
        }

        [Test]
        public void Should_Have_500_StatusCode()
        {
            ObjectResult objectResult = (ObjectResult)ActionResult;
            objectResult.StatusCode.Should().Be(500);
        }

        [Test]
        public void Should_Have_Value_Matching_Given_ErrorDetails()
        {
            ObjectResult objectResult = (ObjectResult)ActionResult;
            objectResult.Value.Should().BeSameAs(ErrorDetails);
        }

    }
}

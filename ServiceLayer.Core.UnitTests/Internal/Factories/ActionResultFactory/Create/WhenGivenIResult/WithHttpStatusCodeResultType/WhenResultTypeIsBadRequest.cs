using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsBadRequest : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsBadRequest() : base(HttpStatusCode.BadRequest)
        {
        }

        [Test]
        public void Should_Return_BadRequestResult()
        {
            ActionResult.Should().BeOfType<BadRequestObjectResult>(); 
        }

        [Test]
        public void Should_Have_Value_Matching_Given_ErrorDetails()
        {
            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)ActionResult;
            badRequestObjectResult.Value.Should().BeSameAs(ErrorDetails);
        }
       
    }
}

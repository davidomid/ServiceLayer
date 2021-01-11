using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsBadRequest : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsBadRequest() : base(HttpStatusCode.BadRequest)
        {
        }

        [Test]
        public void Should_Return_BadRequestResult()
        {
            ActionResult.Should().BeOfType<BadRequestResult>(); 
        }
    }
}

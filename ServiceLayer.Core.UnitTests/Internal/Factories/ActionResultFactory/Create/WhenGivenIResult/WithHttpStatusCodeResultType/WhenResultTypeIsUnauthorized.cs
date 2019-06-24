using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsUnauthorized : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsUnauthorized() : base(HttpStatusCode.Unauthorized)
        {
        }

        [Test]
        public void Should_Return_UnauthorizedResult()
        {
            ActionResult.Should().BeOfType<UnauthorizedResult>(); 
        }
    }
}

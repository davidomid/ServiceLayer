using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsUnauthorized : GivenAnHttpServiceResultType
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

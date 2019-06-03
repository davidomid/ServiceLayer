using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsUnauthorized : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsUnauthorized() : base(HttpServiceResultTypes.Unauthorized)
        {
        }

        [Test]
        public void Should_Return_UnauthorizedResult()
        {
            ActionResult.Should().BeOfType<UnauthorizedResult>(); 
        }
    }
}

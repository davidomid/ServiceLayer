using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsNotFound : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsNotFound() : base(HttpStatusCode.NotFound)
        {
        }

        [Test]
        public void Should_Return_NotFoundResult()
        {
            ActionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundResult>(); 
        }
    }
}

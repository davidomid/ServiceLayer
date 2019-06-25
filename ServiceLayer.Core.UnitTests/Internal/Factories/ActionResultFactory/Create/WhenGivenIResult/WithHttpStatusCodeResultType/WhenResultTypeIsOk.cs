using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsOk : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsOk() : base(HttpStatusCode.OK)
        {
        }

        [Test]
        public void Should_Return_OkResult()
        {
            ActionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkResult>(); 
        }
    }
}

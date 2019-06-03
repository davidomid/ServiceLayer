using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsOk : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsOk() : base(HttpServiceResultTypes.Ok)
        {
        }

        [Test]
        public void Should_Return_OkResult()
        {
            ActionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkResult>(); 
        }
    }
}

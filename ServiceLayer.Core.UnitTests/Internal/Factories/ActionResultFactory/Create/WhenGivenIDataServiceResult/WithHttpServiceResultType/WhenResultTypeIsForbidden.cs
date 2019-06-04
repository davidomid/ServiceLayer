using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsForbidden : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsForbidden() : base(HttpServiceResultTypes.Forbidden)
        {
        }

        [Test]
        public void Should_Return_ForbidResult()
        {
            ActionResult.Should().BeOfType<ForbidResult>(); 
        }
    }
}

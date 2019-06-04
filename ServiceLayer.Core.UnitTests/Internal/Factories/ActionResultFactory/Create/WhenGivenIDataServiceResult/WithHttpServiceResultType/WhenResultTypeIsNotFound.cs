using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsNotFound : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsNotFound() : base(HttpServiceResultTypes.NotFound)
        {
        }

        [Test]
        public void Should_Return_NotFoundResult()
        {
            ActionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundResult>(); 
        }
    }
}

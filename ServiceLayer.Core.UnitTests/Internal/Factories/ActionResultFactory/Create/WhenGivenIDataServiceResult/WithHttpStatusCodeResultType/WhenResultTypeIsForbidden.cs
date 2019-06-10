using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsForbidden : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsForbidden() : base(HttpStatusCode.Forbidden)
        {
        }

        [Test]
        public void Should_Return_ForbidResult()
        {
            ActionResult.Should().BeOfType<ForbidResult>(); 
        }
    }
}

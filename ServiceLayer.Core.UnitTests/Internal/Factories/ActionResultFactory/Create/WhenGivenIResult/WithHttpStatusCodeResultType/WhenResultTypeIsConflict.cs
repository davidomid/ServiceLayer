using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsConflict : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsConflict() : base(HttpStatusCode.Conflict)
        {
        }

        [Test]
        public void Should_Return_ConflictResult()
        {
            ActionResult.Should().BeOfType<ConflictResult>();
        }
    }
}

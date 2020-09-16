using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataResult.WithHttpStatusCodeResultType
{
    public class WhenResultTypeIsInternalServerError : GivenAnHttpStatusCodeResultType
    {
        public WhenResultTypeIsInternalServerError() : base(HttpStatusCode.InternalServerError)
        {
        }

        [Test]
        public void Should_Return_StatusCodeResult()
        {
            ActionResult.Should().BeOfType<StatusCodeResult>(); 
        }

        [Test]
        public void Should_Have_500_StatusCode()
        {
            StatusCodeResult statusCodeResult = (StatusCodeResult)ActionResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }
    }
}

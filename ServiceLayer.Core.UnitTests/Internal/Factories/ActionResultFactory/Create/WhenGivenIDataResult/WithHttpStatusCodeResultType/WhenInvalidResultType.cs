using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataResult.WithHttpStatusCodeResultType
{
    public class WhenInvalidResultType : GivenAnHttpStatusCodeResultType
    {
        private const HttpStatusCode HttpStatusCode = (HttpStatusCode)999;
         
        public WhenInvalidResultType() : base(HttpStatusCode)
        {
        }

        [Test]
        public void Should_Return_StatusCodeResult()
        {
            ActionResult.Should().BeOfType<StatusCodeResult>(); 
        }

        [Test]
        public void Should_Have_Expected_StatusCode()
        {
            StatusCodeResult statusCodeResult = (StatusCodeResult)ActionResult;
            statusCodeResult.StatusCode.Should().Be((int)HttpStatusCode);
        }
    }
}

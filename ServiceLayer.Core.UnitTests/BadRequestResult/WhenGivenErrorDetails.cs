using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests.BadRequestResult
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private Core.BadRequestResult _badRequestResult;
        private string[] _errorDetails;

        [Test]
        public void Should_Have_BadRequest_ResultType()
        {
            _badRequestResult.ResultType.Should().Be(HttpServiceResultTypes.BadRequest);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _badRequestResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _badRequestResult = new Core.BadRequestResult(_errorDetails);
        }
    }
}

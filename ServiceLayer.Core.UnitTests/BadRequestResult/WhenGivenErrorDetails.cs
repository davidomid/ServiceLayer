using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.BadRequestResult
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private Core.BadRequestResult _badRequestResult;
        private readonly object _errorDetails = new object();

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
        }

        protected override void Act()
        {
            _badRequestResult = new Core.BadRequestResult(_errorDetails);
        }
    }
}

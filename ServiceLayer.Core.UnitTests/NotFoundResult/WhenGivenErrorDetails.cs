using System;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.Core.UnitTests.NotFoundResult
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private Core.NotFoundResult _notFoundResult;
        private string[] _errorDetails;

        [Test]
        public void Should_Have_NotFound_ResultType()
        {
            _notFoundResult.ResultType.Should().Be(HttpServiceResultTypes.NotFound);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _notFoundResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _notFoundResult = new Core.NotFoundResult(_errorDetails);
        }
    }
}

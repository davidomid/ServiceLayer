using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.ConflictResult
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private Core.ConflictResult _conflictResult;
        private string[] _errorDetails;

        [Test]
        public void Should_Have_Conflict_ResultType()
        {
            _conflictResult.ResultType.Should().Be(HttpServiceResultTypes.Conflict);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _conflictResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _conflictResult = new Core.ConflictResult(_errorDetails);
        }
    }
}

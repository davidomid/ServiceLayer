using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests.ConflictResult
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private Core.ConflictResult _conflictResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_Conflict_ResultType()
        {
            _conflictResult.ResultType.Should().Be(HttpServiceResultTypes.Conflict);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _conflictResult.ErrorDetails.Should().BeSameAs(_errorMessages); 
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _conflictResult = new Core.ConflictResult(_errorMessages);
        }
    }
}

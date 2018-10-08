using System;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Tests.ConflictResult
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private ServiceLayer.ConflictResult _conflictResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_Conflict_ResultType()
        {
            _conflictResult.ResultType.Should().Be(ServiceResultTypes.Conflict);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _conflictResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _conflictResult = new ServiceLayer.ConflictResult(_errorMessages);
        }
    }
}

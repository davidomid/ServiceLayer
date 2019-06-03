using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.Conflict
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private Core.ConflictResult _conflictResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _conflictResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ConflictResult_With_Equivalent_ErrorDetails()
        {
            _conflictResult.ErrorDetails.Should().BeEquivalentTo(_errorDetails);
        }

        protected override void Act()
        {
            _conflictResult = _service.Conflict(_errorDetails); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

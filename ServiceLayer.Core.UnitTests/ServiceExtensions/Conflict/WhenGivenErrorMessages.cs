using System;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.Conflict
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceLayer.ConflictResult _conflictResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _conflictResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ConflictResult_With_Equivalent_ErrorMessages()
        {
            _conflictResult.ErrorMessages.Should().BeEquivalentTo(_errorMessages);
        }

        protected override void Act()
        {
            _conflictResult = _service.Conflict(_errorMessages); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

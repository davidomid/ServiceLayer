using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Failure
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private FailureResult _failureResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _failureResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_FailureResult_With_Equivalent_ErrorMessages()
        {
            _failureResult.ErrorDetails.Should().BeEquivalentTo(_errorMessages);
        }

        protected override void Act()
        {
            _failureResult = _service.Failure(_errorMessages); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

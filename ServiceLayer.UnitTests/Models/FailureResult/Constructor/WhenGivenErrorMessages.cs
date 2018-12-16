using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_Failure_ServiceResultType()
        {
            _failureResult.ResultType.Should().Be(ServiceResultTypes.Failure);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _failureResult.ErrorMessages.Should().BeSameAs(_errorMessages);
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
           _failureResult = new ServiceLayer.FailureResult(_errorMessages);
        }
    }
}

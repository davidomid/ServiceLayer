using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;
        private string[] _errorDetails;

        [Test]
        public void Should_Have_Failure_ServiceResultType()
        {
            _failureResult.ResultType.Should().Be(ServiceResultTypes.Failure);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _failureResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
           _failureResult = new ServiceLayer.FailureResult(_errorDetails);
        }
    }
}

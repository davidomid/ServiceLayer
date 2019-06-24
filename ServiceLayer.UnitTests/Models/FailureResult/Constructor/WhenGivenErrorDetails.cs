using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;
        private object[] _errorDetails;

        [Test]
        public void Should_Have_Failure_ResultType()
        {
            _failureResult.ResultType.Should().Be(ResultType.Failure);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _failureResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        protected override void Arrange()
        {
            _errorDetails = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
           _failureResult = new ServiceLayer.FailureResult(_errorDetails);
        }
    }
}

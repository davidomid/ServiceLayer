using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Failure
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private FailureResult _failureResult;
        private FailureResult _expectedResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _failureResult.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _failureResult = _service.Failure(_errorDetails); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedResult = MockFailureResultFactory.Object.Create(_errorDetails);
        }
    }
}

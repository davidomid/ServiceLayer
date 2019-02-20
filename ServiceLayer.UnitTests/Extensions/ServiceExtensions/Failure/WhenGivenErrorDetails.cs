using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Failure
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private FailureResult _failureResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _failureResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Have_ErrorDetails_Array_Containing_Same_ErrorDetails_Object()
        {
            _failureResult.ErrorDetails.As<object[]>().Should().BeEquivalentTo((object)_errorDetails);
        }

        protected override void Act()
        {
            _failureResult = _service.Failure(_errorDetails); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

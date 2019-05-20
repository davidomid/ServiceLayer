using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Failure
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private IService _service;
        private FailureResult _failureResult;
        private FailureResult _expectedResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _failureResult.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _failureResult = _service.Failure(); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockFailureResultFactory.Object.Create();
        }
    }
}

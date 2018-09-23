using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Tests.ServiceExtensions.ServiceError
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceErrorResult _serviceErrorResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceErrorResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ServiceErrorResult_With_Equivalent_ErrorMessages()
        {
            _serviceErrorResult.ErrorMessages.Should().BeEquivalentTo(_errorMessages);
        }

        protected override void Act()
        {
            _serviceErrorResult = _service.ServiceError(_errorMessages); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

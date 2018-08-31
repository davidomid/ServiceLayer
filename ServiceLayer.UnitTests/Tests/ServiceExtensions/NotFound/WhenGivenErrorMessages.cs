using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.ServiceExtensions.NotFound
{
    public class WhenGivenErrorMessages : NUnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceLayer.NotFoundResult _notFoundResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _notFoundResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_NotFoundResult_With_Equivalent_ErrorMessages()
        {
            _notFoundResult.ErrorMessages.Should().BeEquivalentTo(_errorMessages);
        }

        protected override void Act()
        {
            _notFoundResult = _service.NotFound(_errorMessages); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

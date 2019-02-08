using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.NotFound
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private Core.NotFoundResult _notFoundResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _notFoundResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_NotFoundResult_With_Equivalent_ErrorMessages()
        {
            _notFoundResult.ErrorDetails.Should().BeEquivalentTo(_errorMessages);
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

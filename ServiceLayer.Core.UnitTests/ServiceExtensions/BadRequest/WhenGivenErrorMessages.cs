using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.BadRequest
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private Core.BadRequestResult _badRequestResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _badRequestResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_BadRequestResult_With_Equivalent_ErrorMessages()
        {
            _badRequestResult.ErrorDetails.Should().BeEquivalentTo(_errorMessages);
        }

        protected override void Act()
        {
            _badRequestResult = _service.BadRequest(_errorMessages); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

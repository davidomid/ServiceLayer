using System;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestData;

namespace ServiceLayer.UnitTests.Tests.ServiceExtensions.BadRequest
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceLayer.BadRequestResult _badRequestResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _badRequestResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_BadRequestResult_With_Equivalent_ErrorMessages()
        {
            _badRequestResult.ErrorMessages.Should().BeEquivalentTo(_errorMessages);
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

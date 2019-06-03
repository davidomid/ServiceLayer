using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.BadRequest
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private Core.BadRequestResult _badRequestResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _badRequestResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_BadRequestResult_With_Equivalent_ErrorDetails()
        {
            _badRequestResult.ErrorDetails.Should().BeEquivalentTo(_errorDetails);
        }

        protected override void Act()
        {
            _badRequestResult = _service.BadRequest(_errorDetails); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

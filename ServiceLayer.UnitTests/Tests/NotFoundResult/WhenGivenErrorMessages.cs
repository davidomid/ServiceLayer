using System;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.NotFoundResult
{
    public class WhenGivenErrorMessages : NUnitTestBase
    {
        private ServiceLayer.NotFoundResult _notFoundResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_NotFound_ResultType()
        {
            _notFoundResult.ResultType.Should().Be(ServiceResultTypes.NotFound);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _notFoundResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _notFoundResult = new ServiceLayer.NotFoundResult(_errorMessages);
        }
    }
}

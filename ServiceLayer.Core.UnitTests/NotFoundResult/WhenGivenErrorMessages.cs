using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests.NotFoundResult
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private Core.NotFoundResult _notFoundResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_NotFound_ResultType()
        {
            _notFoundResult.ResultType.Should().Be(HttpServiceResultTypes.NotFound);
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
            _notFoundResult = new Core.NotFoundResult(_errorMessages);
        }
    }
}

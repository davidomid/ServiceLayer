using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.Core.UnitTests.BadRequestResult
{
    public class WhenGivenErrorMessages : UnitTestBase
    {
        private Core.BadRequestResult _badRequestResult;
        private string[] _errorMessages;

        [Test]
        public void Should_Have_BadRequest_ResultType()
        {
            _badRequestResult.ResultType.Should().Be(HttpServiceResultTypes.BadRequest);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _badRequestResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _badRequestResult = new Core.BadRequestResult(_errorMessages);
        }
    }
}

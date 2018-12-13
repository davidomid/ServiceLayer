using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.IsSuccessful
{
    public class WhenServiceResultTypeFailure : UnitTestBase
    {
        private ServiceResult<ServiceResultTypes> _serviceResult;
        private bool _isSuccessful;

        [Test]
        public void Should_Return_True()
        {
            _isSuccessful.Should().BeFalse();
        }

        protected override void Arrange()
        {
            _serviceResult = new ServiceResult<ServiceResultTypes>(ServiceResultTypes.Failure);
        }

        protected override void Act()
        {
            _isSuccessful = _serviceResult.IsSuccessful;
        }
    }
}

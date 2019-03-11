using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;

namespace ServiceLayer.UnitTests.Models.ServiceResult_1.IsSuccessful
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

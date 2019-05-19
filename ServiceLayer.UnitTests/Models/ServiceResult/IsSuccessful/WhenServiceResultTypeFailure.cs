using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.ServiceResult.IsSuccessful
{
    public class WhenServiceResultTypeFailure : UnitTestBase
    {
        private ServiceLayer.ServiceResult _serviceResult;
        private bool _isSuccessful;

        [Test]
        public void Should_Return_True()
        {
            _isSuccessful.Should().BeFalse();
        }

        protected override void Arrange()
        {
            _serviceResult = new ServiceLayer.ServiceResult(ServiceResultTypes.Failure);
        }

        protected override void Act()
        {
            _isSuccessful = _serviceResult.IsSuccessful;
        }
    }
}

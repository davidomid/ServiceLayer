using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.ServiceResult.IsSuccessful
{
    public class WhenServiceResultTypeSuccess : UnitTestBase
    {
        private ServiceLayer.Result _result;
        private bool _isSuccessful;

        [Test]
        public void Should_Return_True()
        {
            _isSuccessful.Should().BeTrue();
        }

        protected override void Arrange()
        {
            _result = new ServiceLayer.Result(ResultType.Success);
        }

        protected override void Act()
        {
            _isSuccessful = _result.IsSuccessful;
        }
    }
}

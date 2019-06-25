using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.Result.IsSuccessful
{
    public class WhenResultTypeFailure : UnitTestBase
    {
        private ServiceLayer.Result _result;
        private bool _isSuccessful;

        [Test]
        public void Should_Return_True()
        {
            _isSuccessful.Should().BeFalse();
        }

        protected override void Arrange()
        {
            _result = new ServiceLayer.Result(ResultType.Failure);
        }

        protected override void Act()
        {
            _isSuccessful = _result.IsSuccessful;
        }
    }
}

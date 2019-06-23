using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.SuccessResult.Constructor
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private ServiceLayer.SuccessResult _successResult;

        [Test]
        public void Should_Have_Success_ServiceResultType()
        {
            _successResult.ResultType.Should().Be(ResultTypes.Success);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
           _successResult = new ServiceLayer.SuccessResult();
        }
    }
}

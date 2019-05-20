using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Success
{
    public class WhenNoArguments : UnitTestBase
    {
        private IService _service;
        private SuccessResult _successResult;
        private SuccessResult _expectedSuccessResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _successResult.Should().Be(_expectedSuccessResult);
        }

        protected override void Act()
        {
            _successResult = _service.Success(); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedSuccessResult = MockSuccessResultFactory.Object.Create();
        }
    }
}

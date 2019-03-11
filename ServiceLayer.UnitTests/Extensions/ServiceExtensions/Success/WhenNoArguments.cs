using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Success
{
    public class WhenNoArguments : UnitTestBase
    {
        private IService _service;
        private SuccessResult _successResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _successResult.Should().NotBeNull();
        }

        protected override void Act()
        {
            _successResult = _service.Success(); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
        }
    }
}

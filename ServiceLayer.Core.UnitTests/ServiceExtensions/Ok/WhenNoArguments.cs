using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.Core.UnitTests.ServiceExtensions.Ok
{
    public class WhenNoArguments : UnitTestBase
    {
        private IService _service;
        private Core.OkResult _okResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _okResult.Should().NotBeNull();
        }

        protected override void Act()
        {
            _okResult = _service.Ok(); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Tests.ServiceExtensions.Ok
{
    public class WhenGivenData : UnitTestBase
    {
        private IService _service;
        private ServiceLayer.OkResult _okResult;

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

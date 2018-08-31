using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.ServiceExtensions.Ok
{
    public class WhenGivenData : NUnitTestBase
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

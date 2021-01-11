using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.Models;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Inconclusive
{
    public class WhenNoArguments : UnitTestBase
    {
        private IService _service;
        private InconclusiveResult _inconclusiveResult;
        private InconclusiveResult _expectedInconclusiveResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _inconclusiveResult.Should().Be(_expectedInconclusiveResult);
        }

        protected override void Act()
        {
            _inconclusiveResult = _service.Inconclusive(); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedInconclusiveResult = MockInconclusiveResultFactory.Object.Create();
        }
    }
}

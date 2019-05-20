using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Internal.Factories.FailureResultFactory.Create
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.FailureResultFactory _failureResultFactory =
            new ServiceLayer.Internal.Factories.FailureResultFactory();

        private FailureResult _failureResult;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _failureResult = _failureResultFactory.Create(); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _failureResult.Should().NotBeNull();
        }
    }
}

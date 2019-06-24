using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_1.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly global::ServiceLayer.SuccessResult _successResult = new global::ServiceLayer.SuccessResult();

        private Result<TestCustomResultType> _actualResult;

        private Result<TestCustomResultType> _expectedResult;

        [Test]
        public void Should_Be_Expected_Result()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockResultFactory.Object.Create<TestCustomResultType>(_successResult);
        }

        protected override void Act()
        {
            _actualResult = _successResult;
        }
    }
}

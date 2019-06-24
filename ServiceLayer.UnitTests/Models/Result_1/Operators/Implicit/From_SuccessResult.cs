using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_1.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly global::ServiceLayer.SuccessResult _successResult = new global::ServiceLayer.SuccessResult();

        private Result<TestCustomResultTypes> _actualResult;

        private Result<TestCustomResultTypes> _expectedResult;

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockServiceResultFactory.Object.Create<TestCustomResultTypes>(_successResult);
        }

        protected override void Act()
        {
            _actualResult = _successResult;
        }
    }
}

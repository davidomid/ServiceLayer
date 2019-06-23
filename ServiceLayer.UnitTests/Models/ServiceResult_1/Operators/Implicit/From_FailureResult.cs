using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_1.Operators.Implicit
{
    public class From_FailureResult : UnitTestBase
    {
        private readonly ServiceLayer.FailureResult _failureResult = new ServiceLayer.FailureResult();

        private Result<TestCustomServiceResultTypes> _actualResult;

        private Result<TestCustomServiceResultTypes> _expectedResult;

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockServiceResultFactory.Object.Create<TestCustomServiceResultTypes>(_failureResult);
        }

        protected override void Act()
        {
            _actualResult = _failureResult;
        }
    }
}

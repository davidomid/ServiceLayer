using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_2.Operators.Implicit
{
    public class From_CustomErrorType : UnitTestBase
    {
        private readonly TestErrorType _customErrorType = new TestErrorType();

        private Result<TestCustomResultType, TestErrorType> _actualResult;

        private Result<TestCustomResultType, TestErrorType> _expectedResult;

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().BeSameAs(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockServiceResultFactory.Object.Create<TestCustomResultType, TestErrorType>(_customErrorType);
        }

        protected override void Act()
        {
            _actualResult = _customErrorType;
        }
    }
}

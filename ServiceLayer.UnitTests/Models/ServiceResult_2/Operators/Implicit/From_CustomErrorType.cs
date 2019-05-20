using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_2.Operators.Implicit
{
    public class From_CustomErrorType : UnitTestBase
    {
        private readonly TestErrorType _customErrorType = new TestErrorType();

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _actualServiceResult;

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _expectedServiceResult;

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualServiceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Arrange()
        {
            _expectedServiceResult = MockServiceResultFactory.Object.Create<TestCustomServiceResultTypes, TestErrorType>(_customErrorType);
        }

        protected override void Act()
        {
            _actualServiceResult = _customErrorType;
        }
    }
}

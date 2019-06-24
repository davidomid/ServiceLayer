using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_3.Operators.Implicit
{
    public class From_CustomErrorType : UnitTestBase
    {
        private readonly TestErrorType _customErrorType = new TestErrorType();
        private DataResult<TestData, TestCustomResultTypes, TestErrorType> _actualDataResult;
        private DataResult<TestData, TestCustomResultTypes, TestErrorType> _expectedDataResult;

        protected override void Act()
        {
            _actualDataResult = _customErrorType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultTypes, TestErrorType>(_customErrorType);
        }
    }
}

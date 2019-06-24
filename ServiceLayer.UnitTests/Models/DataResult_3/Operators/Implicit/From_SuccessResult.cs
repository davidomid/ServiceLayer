using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_3.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly SuccessResult<TestData> _successResult = new SuccessResult<TestData>(new TestData());
        private DataResult<TestData, TestCustomResultType, TestErrorType> _actualDataResult;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _successResult;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultType, TestErrorType>(_successResult);
        }
    }
}

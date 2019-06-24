using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_3.Operators.Implicit
{
    public class From_Data : UnitTestBase
    {
        private readonly TestData _testData = new TestData();
        private DataResult<TestData, TestCustomResultType, TestErrorType> _actualDataResult;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _testData;
        }

        [Test]
        public void Should_Be_Expected_DataResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataResultFactory.Object.Create<TestData, TestCustomResultType, TestErrorType>(_testData);
        }
    }
}

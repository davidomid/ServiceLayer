using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_3.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly SuccessResult<TestData> _successResult = new SuccessResult<TestData>(new TestData());
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _actualDataServiceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedDataServiceResult;    

        protected override void Act()
        {
            _actualDataServiceResult = _successResult;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().BeSameAs(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_successResult);
        }
    }
}

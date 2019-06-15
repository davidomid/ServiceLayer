using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_3.Operators.Implicit
{
    public class From_CustomErrorType : UnitTestBase
    {
        private readonly TestErrorType _customErrorType = new TestErrorType();
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _actualDataServiceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedDataServiceResult;

        protected override void Act()
        {
            _actualDataServiceResult = _customErrorType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().BeSameAs(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_customErrorType);
        }
    }
}

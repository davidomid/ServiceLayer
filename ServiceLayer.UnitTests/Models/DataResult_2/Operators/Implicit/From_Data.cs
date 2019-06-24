using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_2.Operators.Implicit
{
    public class From_Data : UnitTestBase
    {
        private readonly TestData _testData = new TestData();
        private DataResult<TestData, TestCustomResultTypes> _actualDataResult;
        private DataResult<TestData, TestCustomResultTypes> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _testData;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultTypes>(_testData);
        }
    }
}

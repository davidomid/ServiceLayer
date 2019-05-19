using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Operators.Implicit
{
    public class From_FailureResult : UnitTestBase
    {
        private readonly ServiceLayer.FailureResult _failureResult = new ServiceLayer.FailureResult();
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _actualDataServiceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _expectedDataServiceResult;    

        protected override void Act()
        {
            _actualDataServiceResult = _failureResult;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().BeSameAs(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes>(_failureResult);
        }
    }
}

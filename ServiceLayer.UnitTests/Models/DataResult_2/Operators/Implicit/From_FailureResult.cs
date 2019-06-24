using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_2.Operators.Implicit
{
    public class From_FailureResult : UnitTestBase
    {
        private readonly ServiceLayer.FailureResult _failureResult = new ServiceLayer.FailureResult();
        private DataResult<TestData, TestCustomResultType> _actualDataResult;
        private DataResult<TestData, TestCustomResultType> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _failureResult;
        }

        [Test]
        public void Should_Be_Expected_DataResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataResultFactory.Object.Create<TestData, TestCustomResultType>(_failureResult);
        }
    }
}

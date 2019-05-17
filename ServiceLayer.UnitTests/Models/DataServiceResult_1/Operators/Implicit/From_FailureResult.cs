using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_1.Operators.Implicit
{
    public class From_FailureResult : UnitTestBase
    {
        private readonly ServiceLayer.FailureResult _failureResult = new ServiceLayer.FailureResult();
        private DataServiceResult<TestData> _actualDataServiceResult;
        private DataServiceResult<TestData> _expectedDataServiceResult;    

        protected override void Act()
        {
            _actualDataServiceResult = _failureResult;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().Be(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData>(_failureResult);
        }
    }
}

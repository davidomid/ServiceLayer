using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData
{
    public class WhenGivenFailureResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData> _result;

        private object[] _errorDetails;
        private FailureResult _failureResult;

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(ResultTypes.Failure);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _result.Data.Should().BeNull();
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData>(_failureResult);
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { "test error 1", "test error 2", "test error 3" };
            _failureResult = new FailureResult(_errorDetails);
        }
    }
}


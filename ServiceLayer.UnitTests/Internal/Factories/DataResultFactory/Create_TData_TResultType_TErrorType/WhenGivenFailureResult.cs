using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenFailureResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultTypes, TestErrorType> _result;

        private TestErrorType _errorDetails;
        private FailureResult<TestErrorType> _failureResult;

        private TestCustomResultTypes _expectedResultType =
            TestCustomResultTypes.TestValueWithFailureAttribute;

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _result.Data.Should().BeNull();
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultTypes, TestErrorType>(_failureResult);
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultTypes>(ResultType.Success))
                .Returns(_expectedResultType);
            _errorDetails = new TestErrorType();
            _failureResult = new FailureResult<TestErrorType>(_errorDetails);
        }
    }
}

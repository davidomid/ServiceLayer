using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenFailureResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultType, TestErrorType> _result;

        private TestErrorType _errorDetails;
        private FailureResult<TestErrorType> _failureResult;

        private TestCustomResultType _expectedResultType =
            TestCustomResultType.TestValueWithFailureAttribute;

        [Test]
        public void Should_Return_DataResult_With_Expected_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_DataResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataResult_With_Null_Data()
        {
            _result.Data.Should().BeNull();
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultType, TestErrorType>(_failureResult);
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultType>(ResultType.Success))
                .Returns(_expectedResultType);
            _errorDetails = new TestErrorType();
            _failureResult = new FailureResult<TestErrorType>(_errorDetails);
        }
    }
}


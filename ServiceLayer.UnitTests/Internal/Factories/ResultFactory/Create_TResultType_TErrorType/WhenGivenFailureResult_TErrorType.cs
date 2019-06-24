using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ResultFactory.Create_TResultType_TErrorType
{
    public class WhenGivenFailureResult_TErrorType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private readonly FailureResult<TestErrorType> _failureResult = new FailureResult<TestErrorType>(new TestErrorType());

        private Result<TestCustomResultTypes, TestErrorType> _result;

        private readonly TestCustomResultTypes _expectedResultType =
            TestCustomResultTypes.TestValueWithFailureAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultTypes>(ResultType.Failure))
                .Returns(_expectedResultType);
            _result = _resultFactory.Create<TestCustomResultTypes, TestErrorType>(_failureResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().Be(_failureResult.ErrorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }
    }
}

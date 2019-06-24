using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ResultFactory.Create_TResultType_TErrorType
{
    public class WhenGivenSuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private readonly SuccessResult _successResult = new SuccessResult();

        private Result<TestCustomResultTypes, TestErrorType> _result;

        private readonly TestCustomResultTypes _expectedResultType =
            TestCustomResultTypes.TestValueWithSuccessAttribute;

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultTypes>(ResultType.Success))
                .Returns(_expectedResultType);
        }

        protected override void Act()
        {
            _result = _resultFactory.Create<TestCustomResultTypes, TestErrorType>(_successResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_successResult.ErrorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }
    }
}

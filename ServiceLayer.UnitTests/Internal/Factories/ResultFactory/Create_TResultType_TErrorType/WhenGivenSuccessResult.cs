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

        private Result<TestCustomResultType, TestErrorType> _result;

        private readonly TestCustomResultType _expectedResultType =
            TestCustomResultType.TestValueWithSuccessAttribute;

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultType>(ResultType.Success))
                .Returns(_expectedResultType);
        }

        protected override void Act()
        {
            _result = _resultFactory.Create<TestCustomResultType, TestErrorType>(_successResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }
    }
}

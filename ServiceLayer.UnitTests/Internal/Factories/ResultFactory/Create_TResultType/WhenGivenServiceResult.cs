using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Internal.Factories.ResultFactory.Create_TResultType
{
    [TestFixtureSource(nameof(ResultType))]
    public class WhenGivenServiceResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private Result<TestCustomResultTypes> _result;

        private Result _fromResult;

        private readonly ResultType _resultType;

        private readonly TestCustomResultTypes _expectedCustomResultType = (TestCustomResultTypes) 1000;

        private object[] _errorDetails; 

        private static readonly ResultType[] ResultType = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenServiceResult(ResultType resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultTypes>(_resultType))
                .Returns(_expectedCustomResultType);
            _errorDetails = new[] {"test 123", 123, new object()};
            _fromResult = new Result(_resultType, _errorDetails);
        }

        protected override void Act()
        {
            _result = _resultFactory.Create<TestCustomResultTypes>(_fromResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().Be(_errorDetails); 
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedCustomResultType);
        }
    }
}

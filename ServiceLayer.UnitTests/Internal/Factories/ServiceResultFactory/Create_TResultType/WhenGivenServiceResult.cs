using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType
{
    [TestFixtureSource(nameof(ResultType))]
    public class WhenGivenServiceResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private Result<TestCustomServiceResultTypes> _result;

        private Result _fromResult;

        private readonly ResultType _resultType;

        private readonly TestCustomServiceResultTypes _expectedCustomResultType = (TestCustomServiceResultTypes) 1000;

        private object[] _errorDetails; 

        private static readonly ResultType[] ResultType = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenServiceResult(ResultType resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(_resultType))
                .Returns(_expectedCustomResultType);
            _errorDetails = new[] {"test 123", 123, new object()};
            _fromResult = new Result(_resultType, _errorDetails);
        }

        protected override void Act()
        {
            _result = _resultFactory.Create<TestCustomServiceResultTypes>(_fromResult); 
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

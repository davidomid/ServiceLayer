using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType_TErrorType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private readonly TestErrorType _errorDetails = new TestErrorType(); 

        private Result<TestCustomServiceResultTypes, TestErrorType> _result;

        private readonly TestCustomServiceResultTypes _resultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenResultType(TestCustomServiceResultTypes resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _result = _resultFactory.Create(_resultType, _errorDetails); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Given_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Operators.Implicit
{
    public class From_ServiceResult : UnitTestBase
    {
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _testOriginalServiceResult;

        private DataServiceResult<TestData, TestCustomServiceResultTypes> _testNewServiceResult;

        [Test]
        public void Should_Have_Same_ResultType()
        {
            _testNewServiceResult.ResultType.Should().Be(_testOriginalServiceResult.ResultType);
        }

        [Test]
        public void Should_Have_Same_Data()
        {
            _testNewServiceResult.Data.Should().Be(_testOriginalServiceResult.Data);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _testNewServiceResult.ErrorDetails.Should().Be(_testOriginalServiceResult.ErrorDetails);
        }

        protected override void Arrange()
        {
            _testOriginalServiceResult = new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(new TestData(), TestCustomServiceResultTypes.TestValueWithSuccessAttribute, new TestErrorType());
        }

        protected override void Act()
        {
            _testNewServiceResult = _testOriginalServiceResult; 
        }
    }
}

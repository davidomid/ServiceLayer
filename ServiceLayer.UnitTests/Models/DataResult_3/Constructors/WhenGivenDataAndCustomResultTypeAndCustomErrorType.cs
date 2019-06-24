using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_3.Constructors
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndCustomErrorType : UnitTestBase
    {
        private DataResult<TestData, TestCustomResultTypes, TestErrorType> _result;
        private TestErrorType _errorDetails;
        private readonly TestCustomResultTypes _customResultType;
        private TestData _testData;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenDataAndCustomResultTypeAndCustomErrorType(TestCustomResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_customResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _errorDetails = new TestErrorType();
        }

        protected override void Act()
        {
            _result = new DataResult<TestData, TestCustomResultTypes, TestErrorType>(_testData, _customResultType, _errorDetails);
        }
    }
}

using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_1.Constructor
{
    [TestFixtureSource(nameof(ResultType))]
    public class WhenGivenDataAndErrorDetails : UnitTestBase
    {
        private DataResult<TestData> _result;
        private string[] _errorDetails;
        private TestData _testData;

        private readonly ResultType _resultType;

        private static readonly ResultType[] ResultType = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenDataAndErrorDetails(ResultType resultType)
        {
            _resultType = resultType;
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

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _result = new DataResult<TestData>(_testData, _resultType, _errorDetails);
        }
    }
}

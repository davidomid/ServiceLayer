using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultType))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private DataResult<TestData, TestCustomResultType> _result;
        private readonly TestCustomResultType _customResultType;
        private readonly TestData _testData = new TestData();

        private static readonly TestCustomResultType[] ResultType = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenDataAndCustomResultType(TestCustomResultType customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_customResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _result = new DataResult<TestData, TestCustomResultType>(_testData, _customResultType);
        }
    }
}

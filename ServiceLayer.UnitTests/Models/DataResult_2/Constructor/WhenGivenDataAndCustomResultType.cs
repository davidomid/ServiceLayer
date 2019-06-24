using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private DataResult<TestData, TestCustomResultTypes> _result;
        private readonly TestCustomResultTypes _customResultType;
        private readonly TestData _testData = new TestData();

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenDataAndCustomResultType(TestCustomResultTypes customResultType)
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
            _result = new DataResult<TestData, TestCustomResultTypes>(_testData, _customResultType);
        }
    }
}

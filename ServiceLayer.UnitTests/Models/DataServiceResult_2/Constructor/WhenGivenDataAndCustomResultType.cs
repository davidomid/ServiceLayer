using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;
        private readonly TestCustomServiceResultTypes _customResultType;
        private readonly TestData _testData = new TestData();

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultType(TestCustomServiceResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_customResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _serviceResult = new DataServiceResult<TestData, TestCustomServiceResultTypes>(_testData, _customResultType);
        }
    }
}

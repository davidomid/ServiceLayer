using System;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_1.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenData : UnitTestBase
    {
        private DataServiceResult<TestData> _serviceResult;
        private readonly TestData _testData = new TestData();

        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenData(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
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

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _serviceResult = new DataServiceResult<TestData>(_testData, _serviceResultType);
        }
    }
}

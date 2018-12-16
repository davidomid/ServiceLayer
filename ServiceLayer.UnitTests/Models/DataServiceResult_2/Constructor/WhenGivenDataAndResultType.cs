using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndResultType : UnitTestBase
    {
        private DataServiceResult<TestData, ServiceResultTypes> _serviceResult;
        private readonly ServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenDataAndResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_No_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeEmpty(); 
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
            _serviceResult = new DataServiceResult<TestData, ServiceResultTypes>(_testData, _serviceResultType);
        }
    }
}

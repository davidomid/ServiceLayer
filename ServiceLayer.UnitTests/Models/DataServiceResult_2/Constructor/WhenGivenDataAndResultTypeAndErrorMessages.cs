using System;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndErrorDetails : UnitTestBase
    {
        private DataServiceResult<TestData, ServiceResultTypes> _serviceResult;
        private string[] _errorDetails;
        private readonly ServiceResultTypes _serviceResultType;
        private TestData _testData;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenDataAndErrorDetails(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = new DataServiceResult<TestData, ServiceResultTypes>(_testData, _serviceResultType, _errorDetails);
        }
    }
}

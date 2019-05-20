using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultTypeAndCustomErrorDetails : UnitTestBase
    {
        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _serviceResult;
        private TestErrorType _errorDetails;
        private readonly TestCustomServiceResultTypes _customResultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenCustomResultTypeAndCustomErrorDetails(TestCustomServiceResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new TestErrorType();
        }

        protected override void Act()
        {
            _serviceResult = new ServiceResult<TestCustomServiceResultTypes, TestErrorType>(_customResultType, _errorDetails);
        }
    }
}

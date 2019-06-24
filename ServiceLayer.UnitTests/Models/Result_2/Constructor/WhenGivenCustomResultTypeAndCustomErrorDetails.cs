using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_2.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultTypeAndCustomErrorDetails : UnitTestBase
    {
        private Result<TestCustomResultTypes, TestErrorType> _result;
        private TestErrorType _errorDetails;
        private readonly TestCustomResultTypes _customResultType;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenCustomResultTypeAndCustomErrorDetails(TestCustomResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new TestErrorType();
        }

        protected override void Act()
        {
            _result = new Result<TestCustomResultTypes, TestErrorType>(_customResultType, _errorDetails);
        }
    }
}

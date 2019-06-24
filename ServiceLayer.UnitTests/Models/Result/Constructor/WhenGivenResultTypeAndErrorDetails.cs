using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.Result.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultTypeAndErrorDetails : UnitTestBase
    {
        private ServiceLayer.Result _result;
        private string[] _errorDetails;
        private readonly ResultType _resultType;

        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenResultTypeAndErrorDetails(ResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails); 
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _result = new ServiceLayer.Result(_resultType, _errorDetails);
        }
    }
}

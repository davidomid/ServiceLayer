using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private ServiceLayer.Result _result;
        private readonly ResultTypes _resultType;

        private static readonly ResultTypes[] ResultTypes = (ResultTypes[])Enum.GetValues(typeof(ResultTypes));

        public WhenGivenResultType(ResultTypes resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _result = new ServiceLayer.Result(_resultType);
        }
    }
}

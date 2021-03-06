using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.Result.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private ServiceLayer.Result _result;
        private readonly ResultType _resultType;

        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenResultType(ResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Have_ResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_resultType);
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

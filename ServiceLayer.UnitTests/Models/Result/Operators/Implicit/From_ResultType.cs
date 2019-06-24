using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.Result.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ResultType : UnitTestBase
    {
        private readonly ResultType _resultType;

        private ServiceLayer.Result _actualResult;

        private ServiceLayer.Result _expectedResult;

        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public From_ResultType(ResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Be_Expected_Result()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockResultFactory.Object.Create(_resultType);
        }

        protected override void Act()
        {
            _actualResult = _resultType;
        }
    }
}

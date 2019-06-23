using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.ServiceResult.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ResultTypes _resultType;

        private ServiceLayer.Result _actualResult;

        private ServiceLayer.Result _expectedResult;

        private static readonly ResultTypes[] ResultTypes = (ResultTypes[])Enum.GetValues(typeof(ResultTypes));

        public From_ServiceResultType(ResultTypes resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockServiceResultFactory.Object.Create(_resultType);
        }

        protected override void Act()
        {
            _actualResult = _resultType;
        }
    }
}

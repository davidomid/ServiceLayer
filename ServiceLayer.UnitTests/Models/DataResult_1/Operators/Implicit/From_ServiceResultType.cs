using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_1.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ResultType _resultType;
        private DataResult<TestData> _actualDataResult;
        private DataResult<TestData> _expectedDataResult;

        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public From_ServiceResultType(ResultType resultType)
        {
            _resultType = resultType;
        }

        protected override void Act()
        {
            _actualDataResult = _resultType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().Be(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData>(_resultType);
        }
    }
}

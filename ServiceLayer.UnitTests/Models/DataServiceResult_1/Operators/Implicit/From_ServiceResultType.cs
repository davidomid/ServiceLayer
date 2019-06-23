using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_1.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ResultTypes _resultType;
        private DataResult<TestData> _actualDataResult;
        private DataResult<TestData> _expectedDataResult;

        private static readonly ResultTypes[] ResultTypes = (ResultTypes[])Enum.GetValues(typeof(ResultTypes));

        public From_ServiceResultType(ResultTypes resultType)
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

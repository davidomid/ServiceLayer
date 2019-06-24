using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_3.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomResultType _customResultType;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _actualDataResult;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _expectedDataResult;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public From_CustomResultType(TestCustomResultType customResultType)
        {
            _customResultType = customResultType;
        }

        protected override void Act()
        {
            _actualDataResult = _customResultType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultType, TestErrorType>(_customResultType);
        }
    }
}

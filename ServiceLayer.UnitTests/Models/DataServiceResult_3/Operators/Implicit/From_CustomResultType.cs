using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_3.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomServiceResultTypes _customResultType;
        private DataResult<TestData, TestCustomServiceResultTypes, TestErrorType> _actualDataResult;
        private DataResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedDataResult;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public From_CustomResultType(TestCustomServiceResultTypes customResultType)
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
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_customResultType);
        }
    }
}

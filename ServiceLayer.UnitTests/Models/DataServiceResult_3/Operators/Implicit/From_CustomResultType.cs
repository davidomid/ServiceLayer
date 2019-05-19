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
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _actualDataServiceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedDataServiceResult;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public From_CustomResultType(TestCustomServiceResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        protected override void Act()
        {
            _actualDataServiceResult = _customResultType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().BeSameAs(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_customResultType);
        }
    }
}

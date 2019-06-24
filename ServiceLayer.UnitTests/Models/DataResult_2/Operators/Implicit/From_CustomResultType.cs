using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_2.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomResultTypes _customResultType;
        private DataResult<TestData, TestCustomResultTypes> _actualDataResult;
        private DataResult<TestData, TestCustomResultTypes> _expectedDataResult;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public From_CustomResultType(TestCustomResultTypes customResultType)
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
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultTypes>(_customResultType);
        }
    }
}

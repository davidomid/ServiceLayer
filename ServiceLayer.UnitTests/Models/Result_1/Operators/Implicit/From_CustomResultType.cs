using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_1.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomResultTypes _customResultType;

        private Result<TestCustomResultTypes> _actualResult;

        private Result<TestCustomResultTypes> _expectedResult;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public From_CustomResultType(TestCustomResultTypes customResultType)
        {
            _customResultType = customResultType; 
        }

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().Be(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockServiceResultFactory.Object.Create(_customResultType);
        }

        protected override void Act()
        {
            _actualResult = _customResultType;
        }
    }
}

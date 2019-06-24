using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_2.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomResultType _customResultType;

        private Result<TestCustomResultType, TestErrorType> _actualResult;

        private Result<TestCustomResultType, TestErrorType> _expectedResult;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public From_CustomResultType(TestCustomResultType customResultType)
        {
            _customResultType = customResultType; 
        }

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualResult.Should().BeSameAs(_expectedResult);
        }

        protected override void Arrange()
        {
            _expectedResult = MockResultFactory.Object.Create<TestCustomResultType, TestErrorType>(_customResultType);
        }

        protected override void Act()
        {
            _actualResult = _customResultType;
        }
    }
}

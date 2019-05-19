using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_2.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_CustomResultType : UnitTestBase
    {
        private readonly TestCustomServiceResultTypes _customResultType;

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _actualServiceResult;

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _expectedServiceResult;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public From_CustomResultType(TestCustomServiceResultTypes customResultType)
        {
            _customResultType = customResultType; 
        }

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualServiceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Arrange()
        {
            _expectedServiceResult = MockServiceResultFactory.Object.Create<TestCustomServiceResultTypes, TestErrorType>(_customResultType);
        }

        protected override void Act()
        {
            _actualServiceResult = _customResultType;
        }
    }
}

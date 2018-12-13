using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestData;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToServiceResultType
{ 
    public class WhenGivenEnumValueWithNoSuccessAttribute : UnitTestBase
    {
        private readonly ServiceResultTypes _expectedServiceResultType = ServiceResultTypes.Failure;
        private ServiceResultTypes _actualServiceResultType;

        private TestCustomServiceResultTypes _testCustomServiceResultTypes =
            TestCustomServiceResultTypes.TestValueWithNoAttribute;

        [Test]
        public void Should_Return_Failure_ServiceResultTypes_Value()
        {
            _actualServiceResultType.Should().Be(_expectedServiceResultType);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _actualServiceResultType = _testCustomServiceResultTypes.ToServiceResultType();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToServiceResultType
{ 
    public class WhenGivenEnumValueWithSuccessAttribute : UnitTestBase
    {
        private readonly ServiceResultTypes _expectedServiceResultType = ServiceResultTypes.Success;
        private ServiceResultTypes _actualServiceResultType;

        private TestCustomServiceResultTypes _testCustomServiceResultTypes =
            TestCustomServiceResultTypes.TestValueWithSuccessAttribute;

        [Test]
        public void Should_Return_Success_ServiceResultTypes_Value()
        {
            _actualServiceResultType.Should().Be(_expectedServiceResultType);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _actualServiceResultType = _testCustomServiceResultTypes.ToResultType<ServiceResultTypes>();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenSuccessServiceResultType_ForResultTypeWithSuccessAttribute : UnitTestBase
    {
        private const ServiceResultTypes SuccessServiceResultType = ServiceResultTypes.Success;

        private TestCustomServiceResultTypes _testCustomServiceResultType;

        [Test]
        public void Should_Return_TestValueWithSuccessAttribute()
        {
            _testCustomServiceResultType.Should().Be(TestCustomServiceResultTypes.TestValueWithSuccessAttribute);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _testCustomServiceResultType = SuccessServiceResultType.ToResultType<TestCustomServiceResultTypes>();
        }
    }
}

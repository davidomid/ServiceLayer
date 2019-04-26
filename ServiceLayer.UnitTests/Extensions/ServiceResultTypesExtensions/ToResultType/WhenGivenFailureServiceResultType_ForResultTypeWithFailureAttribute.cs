using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenFailureServiceResultType_ForResultTypeWithFailureAttribute : UnitTestBase
    {
        private const ServiceResultTypes FailureServiceResultType = ServiceResultTypes.Failure;

        private TestCustomServiceResultTypes _testCustomServiceResultType;

        [Test]
        public void Should_Return_TestValueWithFailureAttribute()
        {
            _testCustomServiceResultType.Should().Be(TestCustomServiceResultTypes.TestValueWithFailureAttribute);
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _testCustomServiceResultType = FailureServiceResultType.ToResultType<TestCustomServiceResultTypes>();
        }
    }
}

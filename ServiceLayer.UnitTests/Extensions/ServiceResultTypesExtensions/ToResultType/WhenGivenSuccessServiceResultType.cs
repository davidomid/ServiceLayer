using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenSuccessServiceResultType : UnitTestBase
    {
        private readonly ServiceResultTypes _serviceResultType = ServiceResultTypes.Success;

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
            _testCustomServiceResultType = _serviceResultType.ToResultType<TestCustomServiceResultTypes>();
        }
    }
}

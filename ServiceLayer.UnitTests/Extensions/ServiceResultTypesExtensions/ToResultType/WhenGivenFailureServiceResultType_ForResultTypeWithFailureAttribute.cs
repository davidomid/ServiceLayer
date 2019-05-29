using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
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
            //Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>> mockConverter = new Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>>();
            //mockConverter.Setup(c => c.Convert((Enum)ServiceResultTypes.Success)).Returns(_expectedResultType);
        }

        protected override void Act()
        {
            _testCustomServiceResultType = FailureServiceResultType.ToResultType<TestCustomServiceResultTypes>();
        }
    }
}

using System;
using System.Runtime.Serialization;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenSuccessResultType_ForResultTypeWithoutSuccessAttributes : UnitTestBase
    {
        private const ServiceResultTypes SuccessServiceResultType = ServiceResultTypes.Success;

        private Exception _actualException;

        [Test]
        public void Should_Throw_InvalidCastException()
        {
            _actualException.Should().BeOfType<InvalidCastException>();
        }

        [Test]
        public void Should_Throw_Exception_With_Expected_Message()
        {
            _actualException.Message
                .Should()
                .Be($"No valid enum value of type {typeof(TestCustomServiceResultTypesWithNoAttributes)} could be found for the {typeof(ServiceResultTypes)} value \"{SuccessServiceResultType}\"");
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            try
            {
                SuccessServiceResultType.ToResultType<TestCustomServiceResultTypesWithNoAttributes>();
            }
            catch (Exception ex)
            {
                _actualException = ex;
            }
        }
    }
}

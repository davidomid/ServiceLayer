using System;
using System.Runtime.Serialization;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenFailureResultType_ForResultTypeWithoutFailureAttributes : UnitTestBase
    {
        private const ServiceResultTypes FailureServiceResultType = ServiceResultTypes.Failure;

        private Exception _actualException;

        [Test]
        public void Should_Throw_ArgumentException()
        {
            _actualException.Should().BeOfType<ArgumentException>();
        }

        [Test]
        public void Should_Throw_Exception_With_Expected_Message()
        {
            _actualException.Message
                .Should()
                .Be($"No valid enum value of type {typeof(TestCustomServiceResultTypesWithNoAttributes)} could be found for the {typeof(ServiceResultTypes)} value \"{FailureServiceResultType}\"");
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            try
            {
                FailureServiceResultType.ToResultType<TestCustomServiceResultTypesWithNoAttributes>();
            }
            catch (Exception ex)
            {
                _actualException = ex;
            }
        }
    }
}

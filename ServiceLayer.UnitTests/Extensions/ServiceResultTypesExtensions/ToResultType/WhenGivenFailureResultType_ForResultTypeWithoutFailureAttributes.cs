using System;
using System.Runtime.Serialization;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal.Services;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceResultTypesExtensions.ToResultType
{ 
    public class WhenGivenFailureResultType_ForResultTypeWithoutFailureAttributes : UnitTestBase
    {
        private const ServiceResultTypes FailureServiceResultType = ServiceResultTypes.Failure;

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
                .Be($"No valid enum value of type {typeof(TestCustomServiceResultTypesWithNoAttributes)} could be found for the {typeof(ServiceResultTypes)} value \"{FailureServiceResultType}\"");
        }

        protected override void Arrange()
        {
            Mock<IResultTypeConversionService> mockConversionService = new Mock<IResultTypeConversionService>();
            MockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(mockConversionService.Object);
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

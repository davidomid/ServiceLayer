using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType_TErrorType
{
    public class WhenGivenFailureResult_TErrorType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ServiceResultFactory _serviceResultFactory =
            new ServiceLayer.Internal.Factories.ServiceResultFactory();

        private readonly FailureResult<TestErrorType> _failureResult = new FailureResult<TestErrorType>(new TestErrorType());

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private readonly TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithFailureAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            Mock<IResultTypeConversionService> mockConversionService = new Mock<IResultTypeConversionService>();
            mockConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(ServiceResultTypes.Success))
                .Returns(_expectedResultType);
            MockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(mockConversionService.Object);
            _serviceResult = _serviceResultFactory.Create<TestCustomServiceResultTypes, TestErrorType>(_failureResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().Be(_failureResult.ErrorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }
    }
}

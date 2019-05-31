using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType
{
    public class WhenGivenFailureResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;

        private TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithFailureAttribute;
        private object[] _errorDetails;
        private FailureResult _failureResult;

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _serviceResult.Data.Should().BeNull();
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes>(_failureResult);
        }

        protected override void Arrange()
        {
            Mock<IResultTypeConversionService> mockConversionService = new Mock<IResultTypeConversionService>();
            mockConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(ServiceResultTypes.Failure))
                .Returns(_expectedResultType);
            MockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(mockConversionService.Object);
            _errorDetails = new[] { "test error 1", "test error 2", "test error 3" };
            _failureResult = new FailureResult(_errorDetails);
        }
    }
}


using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenFailureResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private TestErrorType _errorDetails;
        private FailureResult<TestErrorType> _failureResult;

        private TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithFailureAttribute;

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
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_failureResult);
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(ServiceResultTypes.Success))
                .Returns(_expectedResultType);
            _errorDetails = new TestErrorType();
            _failureResult = new FailureResult<TestErrorType>(_errorDetails);
        }
    }
}


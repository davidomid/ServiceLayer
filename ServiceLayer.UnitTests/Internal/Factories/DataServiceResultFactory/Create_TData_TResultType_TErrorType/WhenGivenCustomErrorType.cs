using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenCustomErrorType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private readonly TestErrorType _errorDetails = new TestErrorType();

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().Be(_errorDetails);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(ServiceResultTypes.Failure.ToResultType<TestCustomServiceResultTypes>());
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _serviceResult.Data.Should().BeNull();
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_errorDetails);
        }

        protected override void Arrange()
        {
        }
    }
}


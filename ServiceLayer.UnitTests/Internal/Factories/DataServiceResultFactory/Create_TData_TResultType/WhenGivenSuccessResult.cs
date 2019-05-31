using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType
{
    public class WhenGivenSuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;

        private TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithSuccessAttribute;
        private TestData _testData;
        private SuccessResult<TestData> _successResult;

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes>(_successResult);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _successResult = new SuccessResult<TestData>(_testData);
            Mock<IResultTypeConversionService> mockConversionService = new Mock<IResultTypeConversionService>();
            mockConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(ServiceResultTypes.Success))
                .Returns(_expectedResultType);
            MockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(mockConversionService.Object);
        }
    }
}


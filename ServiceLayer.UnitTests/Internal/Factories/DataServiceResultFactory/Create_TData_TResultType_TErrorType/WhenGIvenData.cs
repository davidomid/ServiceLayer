using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private readonly TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithSuccessAttribute;
        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_testData);
        }

        protected override void Arrange()
        {
            Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>> mockConverter = new Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>>();
            mockConverter.Setup(c => c.Convert((Enum)ServiceResultTypes.Success)).Returns(_expectedResultType);
            ServiceResultConfiguration.ResultTypeConverters.ConvertToFromSpecific.AddOrReplace(mockConverter.Object);
        }
    }
}


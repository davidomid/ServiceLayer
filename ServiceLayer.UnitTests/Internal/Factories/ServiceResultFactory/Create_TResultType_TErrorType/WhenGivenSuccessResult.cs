using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType_TErrorType
{
    public class WhenGivenSuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ServiceResultFactory _serviceResultFactory =
            new ServiceLayer.Internal.Factories.ServiceResultFactory();

        private readonly SuccessResult _successResult = new SuccessResult();

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private readonly TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithSuccessAttribute;

        protected override void Arrange()
        {
            Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>> mockConverter = new Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>>();
            mockConverter.Setup(c => c.Convert((Enum)ServiceResultTypes.Success)).Returns(_expectedResultType);
            ServiceResultConfiguration.ResultTypeConverters.ConvertToFromSpecific.AddOrReplace(mockConverter.Object);
        }

        protected override void Act()
        {
            _serviceResult = _serviceResultFactory.Create<TestCustomServiceResultTypes, TestErrorType>(_successResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_successResult.ErrorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }
    }
}

using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType_TErrorType
{
    public class WhenGivenServiceResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ServiceResultFactory _serviceResultFactory =
            new ServiceLayer.Internal.Factories.ServiceResultFactory();

        private readonly TestErrorType _errorDetails = new TestErrorType(); 

        private ServiceResult<TestCustomServiceResultTypes, TestErrorType> _serviceResult;

        private readonly TestCustomServiceResultTypes _expectedResultType =
            TestCustomServiceResultTypes.TestValueWithFailureAttribute;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>> mockConverter = new Mock<IResultTypeConverter<ServiceResultTypes, TestCustomServiceResultTypes>>();
            mockConverter.Setup(c => c.Convert((Enum)ServiceResultTypes.Failure)).Returns(_expectedResultType);
            ServiceResultConfiguration.ResultTypeConverters.Specific.AddOrReplace(mockConverter.Object);
            _serviceResult = _serviceResultFactory.Create<TestCustomServiceResultTypes, TestErrorType>(_errorDetails); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }
    }
}

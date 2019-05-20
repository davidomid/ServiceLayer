using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndGenericErrorTypeArgument : UnitTestBase
    {
        private IService _service;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _serviceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType> _expectedServiceResult; 

        private readonly TestData _testData = new TestData();
        private readonly TestCustomServiceResultTypes _customResultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultTypeAndGenericErrorTypeArgument(TestCustomServiceResultTypes customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(_testData, _customResultType);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedServiceResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(_testData, _customResultType);
        }
    }
}


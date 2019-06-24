using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndGenericErrorTypeArgument : UnitTestBase
    {
        private IService _service;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _result;
        private DataResult<TestData, TestCustomResultType, TestErrorType> _expectedResult; 

        private readonly TestData _testData = new TestData();
        private readonly TestCustomResultType _customResultType;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenDataAndCustomResultTypeAndGenericErrorTypeArgument(TestCustomResultType customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().BeSameAs(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.DataResult<TestData, TestCustomResultType, TestErrorType>(_testData, _customResultType);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomResultType, TestErrorType>(_testData, _customResultType);
        }
    }
}


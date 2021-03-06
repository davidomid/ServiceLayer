using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndCustomErrorType : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private DataResult<TestData, TestCustomResultType, string[]> _result;
        private DataResult<TestData, TestCustomResultType, string[]> _expectedResult;

        private readonly TestCustomResultType _resultType;
        private readonly TestData _testData = new TestData();
        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenDataAndCustomResultTypeAndCustomErrorType(TestCustomResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.DataResult(_testData, _resultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedResult =
                MockDataResultFactory.Object.Create(_testData, _resultType, _errorDetails);
        }
    }
}


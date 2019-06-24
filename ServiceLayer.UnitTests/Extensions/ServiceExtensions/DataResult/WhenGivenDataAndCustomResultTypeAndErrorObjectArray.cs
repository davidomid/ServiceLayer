using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndErrorObjectArray : UnitTestBase
    {
        private IService _service;
        private object[] _errorDetails;
        private DataResult<TestData, TestCustomResultType> _result;
        private DataResult<TestData, TestCustomResultType> _expectedResult;

        private readonly TestCustomResultType _resultType;
        private readonly TestData _testData = new TestData();
        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenDataAndCustomResultTypeAndErrorObjectArray(TestCustomResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().BeSameAs(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.DataResult(_testData, _resultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), 123, new object() };
            _expectedResult =
                MockDataResultFactory.Object.Create(_testData, _resultType, _errorDetails);
        }
    }
}


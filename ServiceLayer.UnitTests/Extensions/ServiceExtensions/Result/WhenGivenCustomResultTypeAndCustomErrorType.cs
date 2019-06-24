using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Result
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultTypeAndCustomErrorType : UnitTestBase
    {
        private IService _service;
        private string[] _errorDetails;
        private Result<TestCustomResultType> _result;
        private Result<TestCustomResultType> _expectedResult;
        private readonly TestCustomResultType _resultType;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenCustomResultTypeAndCustomErrorType(TestCustomResultType resultType)
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
            _result = _service.Result(_resultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedResult = MockServiceResultFactory.Object.Create(_resultType, _errorDetails);
        }
    }
}


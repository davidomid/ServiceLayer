using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Result
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private IService _service;
        private Result<TestCustomResultTypes> _result;
        private Result<TestCustomResultTypes> _expectedResult;
        private readonly TestCustomResultTypes _resultType;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenCustomResultType(TestCustomResultTypes resultType)
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
            _result = _service.Result(_resultType);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedResult = MockServiceResultFactory.Object.Create(_resultType);
        }
    }
}


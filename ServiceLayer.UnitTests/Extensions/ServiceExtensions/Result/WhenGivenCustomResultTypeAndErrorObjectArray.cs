using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Result
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultTypeAndErrorObjectArray : UnitTestBase
    {
        private IService _service;
        private object[] _errorDetails;
        private ServiceLayer.Result _result;
        private ServiceLayer.Result _expectedResult;
        private readonly TestCustomResultType _customResultType;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenCustomResultTypeAndErrorObjectArray(TestCustomResultType customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _result.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _result = _service.Result(_customResultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), 123, new object() };
            _expectedResult = MockResultFactory.Object.Create(_customResultType, _errorDetails);
        }
    }
}


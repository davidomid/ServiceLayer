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
        private ServiceResult<TestCustomServiceResultTypes> _serviceResult;
        private ServiceResult<TestCustomServiceResultTypes> _expectedServiceResult;
        private readonly TestCustomServiceResultTypes _serviceResultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenCustomResultTypeAndCustomErrorType(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().Be(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.Result(_serviceResultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedServiceResult = MockServiceResultFactory.Object.Create(_serviceResultType, _errorDetails);
        }
    }
}


using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Result
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceResult<TestCustomServiceResultTypes> _serviceResult;
        private readonly TestCustomServiceResultTypes _serviceResultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenCustomResultType(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Have_Equivalent_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeEquivalentTo(_errorMessages);
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        protected override void Act()
        {
            _serviceResult = _service.Result(_serviceResultType, _errorMessages);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}

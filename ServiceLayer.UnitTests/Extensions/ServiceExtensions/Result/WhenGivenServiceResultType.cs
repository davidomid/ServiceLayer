using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Result
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultType : UnitTestBase
    {
        private IService _service;
        private string[] _errorMessages;
        private ServiceResult _serviceResult;
        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenServiceResultType(ServiceResultTypes serviceResultType)
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

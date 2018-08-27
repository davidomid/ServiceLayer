using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.ServiceResult.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultTypeAndErrorMessages : NUnitTestBase
    {
        private ServiceLayer.ServiceResult _serviceResult;
        private string[] _errorMessages;
        private readonly ServiceResultTypes _serviceResultType;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenResultTypeAndErrorMessages(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        [Test]
        public void Should_Have_ErrorMessages_Matching_Given_ErrorMessages()
        {
            _serviceResult.ErrorMessages.Should().BeSameAs(_errorMessages); 
        }

        protected override void Arrange()
        {
            _errorMessages = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }

        protected override void Act()
        {
            _serviceResult = new TestServiceResultSubClass(_serviceResultType, _errorMessages);
        }

        private class TestServiceResultSubClass : ServiceLayer.ServiceResult
        {
            public TestServiceResultSubClass(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
            {
            }
        }
    }
}

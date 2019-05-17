using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_1.Operators.Implicit
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class From_ServiceResultType : UnitTestBase
    {
        private readonly ServiceResultTypes _serviceResultType;
        private DataServiceResult<TestData> _actualDataServiceResult;
        private DataServiceResult<TestData> _expectedDataServiceResult;

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public From_ServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        protected override void Act()
        {
            _actualDataServiceResult = _serviceResultType;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataServiceResult.Should().Be(_expectedDataServiceResult);
        }

        protected override void Arrange()
        {
            _expectedDataServiceResult = MockDataServiceResultFactory.Object.Create<TestData>(_serviceResultType);
        }
    }
}

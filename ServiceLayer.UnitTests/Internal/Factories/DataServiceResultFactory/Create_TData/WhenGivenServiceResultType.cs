using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData> _serviceResult;

        private readonly ServiceResultTypes _serviceResultType;
        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenServiceResultType(ServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _serviceResult.Data.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_serviceResultType);
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData>(_serviceResultType);
        }

        protected override void Arrange()
        {
        }
    }
}


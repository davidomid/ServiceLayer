using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.UnitTests;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.DataResult
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private IService _service;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _expectedServiceResult; 

        private readonly TestCustomServiceResultTypes _serviceResultType;
        private readonly TestData _testData = new TestData();

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenDataAndCustomResultType(TestCustomServiceResultTypes serviceResultType)
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
            _serviceResult = _service.DataResult(_testData, _serviceResultType);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedServiceResult = MockDataServiceResultFactory.Object.Create(_testData, _serviceResultType);
        }
    }
}


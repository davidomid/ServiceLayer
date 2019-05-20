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
    public class WhenGivenData : UnitTestBase
    {
        private IService _service;
        private DataServiceResult<TestData> _serviceResult;
        private DataServiceResult<TestData> _expectedServiceResult; 

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_Expected_Result()
        {
            _serviceResult.Should().BeSameAs(_expectedServiceResult);
        }

        protected override void Act()
        {
            _serviceResult = _service.DataResult(_testData);
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _expectedServiceResult = MockDataServiceResultFactory.Object.Create(_testData);
        }
    }
}


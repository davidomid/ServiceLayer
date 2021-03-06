﻿using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataResult_1.Operators.Implicit
{
    public class From_Data : UnitTestBase
    {
        private readonly TestData _testData = new TestData();
        private DataResult<TestData> _actualDataResult;
        private DataResult<TestData> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _testData;
        }

        [Test]
        public void Should_Be_Expected_DataResult()
        {
            _actualDataResult.Should().Be(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataResultFactory.Object.Create(_testData);
        }
    }
}

﻿using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.DataServiceResult_2.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly SuccessResult<TestData> _successResult = new SuccessResult<TestData>(new TestData());
        private DataResult<TestData, TestCustomServiceResultTypes> _actualDataResult;
        private DataResult<TestData, TestCustomServiceResultTypes> _expectedDataResult;    

        protected override void Act()
        {
            _actualDataResult = _successResult;
        }

        [Test]
        public void Should_Be_Expected_DataServiceResult()
        {
            _actualDataResult.Should().BeSameAs(_expectedDataResult);
        }

        protected override void Arrange()
        {
            _expectedDataResult = MockDataServiceResultFactory.Object.Create<TestData, TestCustomServiceResultTypes>(_successResult);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.SuccessResult_1.Operators.Implicit
{
    public class From_Data : UnitTestBase
    {
        private readonly TestData _testData = new TestData();
        private SuccessResult<TestData> _actualSuccessResult;
        private SuccessResult<TestData> _expectedSuccessResult;    

        protected override void Act()
        {
            _actualSuccessResult = _testData;
        }

        [Test]
        public void Should_Be_Expected_SuccessResult()
        {
            _actualSuccessResult.Should().Be(_expectedSuccessResult);
        }

        protected override void Arrange()
        {
            _expectedSuccessResult = MockSuccessResultFactory.Object.Create(_testData);
        }
    }
}

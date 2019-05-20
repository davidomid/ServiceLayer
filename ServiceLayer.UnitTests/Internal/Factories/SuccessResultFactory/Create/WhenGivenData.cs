using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.SuccessResultFactory.Create
{
    public class WhenGivenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.SuccessResultFactory _successResultFactory =
            new ServiceLayer.Internal.Factories.SuccessResultFactory();

        private readonly TestData _testData = new TestData();

        private SuccessResult<TestData> _successResult;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _successResult = _successResultFactory.Create(_testData); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _successResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_Data()
        {
            _successResult.Data.Should().Be(_testData);
        }
    }
}

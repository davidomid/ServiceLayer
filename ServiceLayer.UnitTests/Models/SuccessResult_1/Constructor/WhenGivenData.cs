using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.SuccessResult_1.Constructor
{
    public class WhenGivenData : UnitTestBase
    {
        private readonly TestData _testData = new TestData();
        private SuccessResult<TestData> _successResult;

        [Test]
        public void Should_Have_Success_ServiceResultType()
        {
            _successResult.ResultType.Should().Be(ServiceResultTypes.Success);
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            _successResult.Data.Should().Be(_testData);
        }


        protected override void Arrange()
        {
        }

        protected override void Act()
        {
           _successResult = new SuccessResult<TestData>(_testData);
        }
    }
}

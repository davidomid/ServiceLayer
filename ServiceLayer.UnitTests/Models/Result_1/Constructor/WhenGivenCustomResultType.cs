using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_1.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private Result<TestCustomResultType> _result;
        private readonly TestCustomResultType _customResultType;

        private static readonly TestCustomResultType[] ResultTypes = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenCustomResultType(TestCustomResultType customResultType)
        {
            _customResultType = customResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _result.ResultType.Should().Be(_customResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _result = new Result<TestCustomResultType>(_customResultType);
        }
    }
}

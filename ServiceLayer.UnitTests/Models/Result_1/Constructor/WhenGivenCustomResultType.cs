using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.Result_1.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private Result<TestCustomResultTypes> _result;
        private readonly TestCustomResultTypes _customResultType;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenCustomResultType(TestCustomResultTypes customResultType)
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
            _result = new Result<TestCustomResultTypes>(_customResultType);
        }
    }
}

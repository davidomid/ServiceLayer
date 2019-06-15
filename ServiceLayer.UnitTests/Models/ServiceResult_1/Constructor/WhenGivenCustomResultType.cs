using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_1.Constructor
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private ServiceResult<TestCustomServiceResultTypes> _serviceResult;
        private readonly TestCustomServiceResultTypes _customServiceResultType;

        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenCustomResultType(TestCustomServiceResultTypes customServiceResultType)
        {
            _customServiceResultType = customServiceResultType;
        }

        [Test]
        public void Should_Have_ServiceResultType_Matching_Given_Type()
        {
            _serviceResult.ResultType.Should().Be(_customServiceResultType);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        protected override void Arrange()
        {

        }

        protected override void Act()
        {
            _serviceResult = new ServiceResult<TestCustomServiceResultTypes>(_customServiceResultType);
        }
    }
}

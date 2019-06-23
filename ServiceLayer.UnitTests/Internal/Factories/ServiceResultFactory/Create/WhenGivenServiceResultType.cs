using System;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private Result _result;

        private readonly ResultTypes _resultType;

        private static readonly ResultTypes[] ResultTypes = (ResultTypes[])Enum.GetValues(typeof(ResultTypes));

        public WhenGivenServiceResultType(ResultTypes resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _result = _resultFactory.Create(_resultType);
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }
    }
}

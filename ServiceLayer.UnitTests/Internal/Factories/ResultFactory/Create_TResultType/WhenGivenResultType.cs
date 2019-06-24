using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ResultFactory.Create_TResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private Result<TestCustomResultTypes> _result;

        private readonly TestCustomResultTypes _resultType;

        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenResultType(TestCustomResultTypes resultType)
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
        public void Should_Return_Result_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }
    }
}

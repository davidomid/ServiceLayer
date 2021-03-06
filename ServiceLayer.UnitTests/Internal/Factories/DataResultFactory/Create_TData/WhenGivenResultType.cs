using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData> _result;

        private readonly ResultType _resultType;
        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenResultType(ResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_DataResult_With_Null_Data()
        {
            _result.Data.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData>(_resultType);
        }

        protected override void Arrange()
        {
        }
    }
}


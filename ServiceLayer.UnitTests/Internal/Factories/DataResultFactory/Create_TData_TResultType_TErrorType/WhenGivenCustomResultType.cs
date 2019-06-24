using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType_TErrorType
{
    [TestFixtureSource(nameof(ResultType))]
    public class WhenGivenCustomResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultType, TestErrorType> _result;

        private readonly TestCustomResultType _resultType;
        private static readonly TestCustomResultType[] ResultType = (TestCustomResultType[])Enum.GetValues(typeof(TestCustomResultType));

        public WhenGivenCustomResultType(TestCustomResultType resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_Data()
        {
            _result.Data.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultType, TestErrorType>(_resultType);
        }

        protected override void Arrange()
        {
        }
    }
}


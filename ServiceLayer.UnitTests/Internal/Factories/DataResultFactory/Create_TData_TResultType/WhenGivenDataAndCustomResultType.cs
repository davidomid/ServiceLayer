using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultTypes> _result;

        private readonly TestCustomResultTypes _resultType;
        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        private readonly TestData _testData = new TestData();

        public WhenGivenDataAndCustomResultType(TestCustomResultTypes resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
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
            _result = _dataResultFactory.Create(_testData, _resultType);
        }

        protected override void Arrange()
        {
        }
    }
}


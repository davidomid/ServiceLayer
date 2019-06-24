using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType_TErrorType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenDataAndCustomResultTypeAndCustomErrorType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private string[] _errorDetails;
        private DataResult<TestData, TestCustomResultTypes, string[]> _result;

        private readonly TestCustomResultTypes _resultType;
        private readonly TestData _testData = new TestData();
        private static readonly TestCustomResultTypes[] ResultTypes = (TestCustomResultTypes[])Enum.GetValues(typeof(TestCustomResultTypes));

        public WhenGivenDataAndCustomResultTypeAndCustomErrorType(TestCustomResultTypes resultType)
        {
            _resultType = resultType;
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_resultType);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create(_testData, _resultType, _errorDetails);
        }

        protected override void Arrange()
        {
            _errorDetails = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        }
    }
}


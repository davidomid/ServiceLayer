using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType
{
    public class WhenGivenSuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultType> _result;

        private TestCustomResultType _expectedResultType =
            TestCustomResultType.TestValueWithSuccessAttribute;
        private TestData _testData;
        private SuccessResult<TestData> _successResult;

        [Test]
        public void Should_Return_DataResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultType>(_successResult);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _successResult = new SuccessResult<TestData>(_testData);
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultType>(ResultType.Success))
                .Returns(_expectedResultType);
        }
    }
}


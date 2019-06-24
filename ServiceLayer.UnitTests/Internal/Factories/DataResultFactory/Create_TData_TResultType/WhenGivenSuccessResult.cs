using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType
{
    public class WhenGivenSuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultTypes> _result;

        private TestCustomResultTypes _expectedResultType =
            TestCustomResultTypes.TestValueWithSuccessAttribute;
        private TestData _testData;
        private SuccessResult<TestData> _successResult;

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultTypes>(_successResult);
        }

        protected override void Arrange()
        {
            _testData = new TestData();
            _successResult = new SuccessResult<TestData>(_testData);
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultTypes>(ResultType.Success))
                .Returns(_expectedResultType);
        }
    }
}


using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData_TResultType_TErrorType
{
    public class WhenGivenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomResultType, TestErrorType> _result;

        private readonly TestCustomResultType _expectedResultType =
            TestCustomResultType.TestValueWithSuccessAttribute;
        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_DataResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataResult_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomResultType, TestErrorType>(_testData);
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultType>(ResultType.Success))
                .Returns(_expectedResultType);
        }
    }
}


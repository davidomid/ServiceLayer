using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType
{
    public class WhenGivenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataServiceResultFactory _dataServiceResultFactory = new ServiceLayer.Internal.Factories.DataServiceResultFactory();
        private DataServiceResult<TestData, TestCustomServiceResultTypes> _serviceResult;
        private TestCustomServiceResultTypes _expectedResultType = TestCustomServiceResultTypes.TestValueWithSuccessAttribute;
        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _serviceResult.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_expectedResultType);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().BeNull();
        }

        protected override void Act()
        {
            _serviceResult = _dataServiceResultFactory.Create<TestData, TestCustomServiceResultTypes>(_testData);
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomServiceResultTypes>(ServiceResultTypes.Success))
                .Returns(_expectedResultType);
        }
    }
}


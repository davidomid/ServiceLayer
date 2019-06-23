using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData
{
    public class WhenGIvenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData> _result;

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(ResultTypes.Success);
        }

        [Test]
        public void Should_Return_DataServiceResult_With_Null_ErrorDetails()
        {
            _result.ErrorDetails.Should().BeNull();
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create(_testData);
        }

        protected override void Arrange()
        {
        }
    }
}


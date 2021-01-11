using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataResultFactory.Create_TData
{
    public class WhenGIvenData : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData> _result;

        private readonly TestData _testData = new TestData();

        [Test]
        public void Should_Return_DataResult_With_Expected_Data()
        {
            _result.Data.Should().BeSameAs(_testData);
        }

        [Test]
        public void Should_Return_DataResult_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(ResultType.Success);
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


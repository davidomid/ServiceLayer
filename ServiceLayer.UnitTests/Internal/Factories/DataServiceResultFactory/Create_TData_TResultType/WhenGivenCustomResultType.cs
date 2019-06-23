using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.DataServiceResultFactory.Create_TData_TResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResultType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.DataResultFactory _dataResultFactory = new ServiceLayer.Internal.Factories.DataResultFactory();
        private DataResult<TestData, TestCustomServiceResultTypes> _result;

        private readonly TestCustomServiceResultTypes _serviceResultType;
        private static readonly TestCustomServiceResultTypes[] ResultTypes = (TestCustomServiceResultTypes[])Enum.GetValues(typeof(TestCustomServiceResultTypes));

        public WhenGivenServiceResultType(TestCustomServiceResultTypes serviceResultType)
        {
            _serviceResultType = serviceResultType;
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
            _result.ResultType.Should().Be(_serviceResultType);
        }

        protected override void Act()
        {
            _result = _dataResultFactory.Create<TestData, TestCustomServiceResultTypes>(_serviceResultType);
        }

        protected override void Arrange()
        {
        }
    }
}


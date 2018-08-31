using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.Operators.From_ErrorResult
{
    public class WhenGivenErrorResultInstance : NUnitTestBase
    {
        private ErrorResult _existingErrorResult;
        private ServiceResult<string> _newServiceResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _newServiceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ServiceResult_Of_Same_Type()
        {
            _newServiceResult.ResultType.Should().Be(_existingErrorResult.ResultType);
        }

        [Test]
        public void Should_Return_ServiceResult_With_Equivalent_ErrorMessages()
        {
            _newServiceResult.ErrorMessages.Should().BeEquivalentTo(_existingErrorResult.ErrorMessages);
        }

        [Test]
        public void Should_Return_ServiceResult_With_Data_Default_Value()
        {
            _newServiceResult.Data.Should().Be(default(string)); 
        }

        protected override void Act()
        {
            _newServiceResult = _existingErrorResult;
        }

        protected override void Arrange()
        {
            _existingErrorResult = new ServiceErrorResult("test error message 1", "test error message 2", "test error message 3");
        }
    }
}

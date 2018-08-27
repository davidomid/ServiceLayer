using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.UnitTests.Infrastructure;

namespace ServiceLayer.UnitTests.Tests.Create
{
    public class WhenGivenIServiceResultInstance : NUnitTestBase
    {
        private IServiceResult _existingServiceResult;
        private ServiceResult<string> _newServiceResult;

        [Test]
        public void Should_Not_Return_Null()
        {
            _newServiceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_ServiceResult_Of_Same_Type()
        {
            _newServiceResult.ResultType.Should().Be(_existingServiceResult.ResultType);
        }

        [Test]
        public void Should_Return_ServiceResult_With_Equivalent_ErrorMessages()
        {
            _newServiceResult.ErrorMessages.Should().BeEquivalentTo(_existingServiceResult.ErrorMessages);
        }

        [Test]
        public void Should_Return_ServiceResult_With_Data_Default_Value()
        {
            _newServiceResult.Data.Should().Be(default(string)); 
        }

        protected override void Act()
        {
            _newServiceResult = ServiceResult<string>.Create(_existingServiceResult);
        }

        protected override void Arrange()
        {
            _existingServiceResult = new ServiceErrorResult("test error message 1", "test error message 2", "test error message 3");
        }
    }
}

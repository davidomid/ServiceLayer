using System.Threading;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.ServiceResult.Create
{
    public class WhenGivenIServiceResultInstance : TestBase
    {
        private IServiceResult _existingServiceResult;
        private ServiceLayer.ServiceResult _newServiceResult;

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

        protected override void Act()
        {
            _newServiceResult = ServiceLayer.ServiceResult.Create(_existingServiceResult);
        }

        protected override void Arrange()
        {
            _existingServiceResult = new ServiceErrorResult("test error message 1", "test error message 2", "test error message 3");
        }
    }
}

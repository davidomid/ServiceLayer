using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Tests.Create
{
    public class WhenGivenGenericIServiceResultInstance : UnitTestBase
    {
        private const string TestData = "test data";
        private IServiceResult<string> _existingServiceResult;
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
        public void Should_Return_ServiceResult_With_Same_Data()
        {
            _newServiceResult.Data.Should().Be(_existingServiceResult.Data);
        }

        protected override void Act()
        {
            _newServiceResult = ServiceResult<string>.Create(_existingServiceResult);
        }

        protected override void Arrange()
        {
            _existingServiceResult = new OkResult<string>(TestData); 
        }
    }
}

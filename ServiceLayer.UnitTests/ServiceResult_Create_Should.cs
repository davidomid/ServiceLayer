using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests
{
    [TestFixture]
    public class ServiceResult_Create_Should
    {
        [TestCase]
        public void ReturnNewServiceResultWhenGivenIServiceResultInstance()
        {
            // Arrange
            IServiceResult existingServiceResult = new ServiceErrorResult("test error message 1", "test error message 2", "test error message 3");

            // Act
            ServiceResult newServiceResult = ServiceResult.Create(existingServiceResult);

            // Assert
            newServiceResult.Should().NotBeNull();
            newServiceResult.ResultType.Should().Be(existingServiceResult.ResultType);
            newServiceResult.ErrorMessages.Should().BeEquivalentTo(existingServiceResult.ErrorMessages);
        }

        [TestCase]
        public void ReturnNewServiceResultWhenGivenResultTypeAndErrorMessages()
        {
            // Arrange
            ServiceResultTypes resultType = ServiceResultTypes.Conflict;
            string[] errorMessages = new string[] { "test error message 1", "test error message 2", "test error message 3" };

            // Act
            ServiceResult newServiceResult = ServiceResult.Create(resultType, errorMessages);

            // Assert
            newServiceResult.Should().NotBeNull();
            newServiceResult.ResultType.Should().Be(resultType);
            newServiceResult.ErrorMessages.Should().BeEquivalentTo(errorMessages);
        }
    }
}

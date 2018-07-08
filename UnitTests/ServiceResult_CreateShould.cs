
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer;

namespace UnitTests
{
    [TestFixture]
    public class ServiceResult_CreateShould
    {
        [TestCase]
        public void ReturnNewServiceResultGivenIServiceResult()
        {
            // Arrange
            

            // Act
            ServiceResult serviceResult = ServiceResult.Create(ServiceResultTypes.Ok);

            // Assert
            serviceResult.Should().NotBeNull();
        }
    }
}

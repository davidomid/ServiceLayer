using Moq;
using NUnit.Framework;
using ServiceLayer.Converters;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;
using Testing.Common.Infrastructure;

namespace ServiceLayer.Core.UnitTests
{
    public abstract class UnitTestBase : ScenarioUnitTestBase
    {
        static UnitTestBase()
        {
            SetupMockConverters();
        }

        private static void SetupMockConverters()
        {
            Mock<FromResultTypeConverter<ServiceResultTypes>> mockServiceResultTypeConverter = new Mock<FromResultTypeConverter<ServiceResultTypes>>();
            mockServiceResultTypeConverter.Setup(c =>
                    c.Convert<HttpServiceResultTypes>(It.IsAny<ServiceResultTypes>()))
                .Returns(HttpServiceResultTypes.Ok);
            mockServiceResultTypeConverter.Setup(c =>
                    c.Convert<ServiceResultTypes>(It.IsAny<ServiceResultTypes>()))
                .Returns(ServiceResultTypes.Success);

            ServiceLayerConfiguration.ResultTypeConverters.AddOrReplace(mockServiceResultTypeConverter.Object);
        }
    }
}

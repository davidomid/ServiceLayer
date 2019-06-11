using Testing.Common.Infrastructure;

namespace ServiceLayer.Core.UnitTests
{
    public abstract class UnitTestBase : ScenarioUnitTestBase
    {
        static UnitTestBase()
        {

        }

        private static void SetupMockConverters()
        {
            //Mock<FromResultTypeConverter<ServiceResultTypes>> mockServiceResultTypeConverter = new Mock<FromResultTypeConverter<ServiceResultTypes>>();
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<HttpStatusCode>(It.IsAny<ServiceResultTypes>()))
            //    .Returns(HttpStatusCode.Ok);
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<ServiceResultTypes>(It.IsAny<ServiceResultTypes>()))
            //    .Returns(ServiceResultTypes.Success);

            //ServiceLayerConfiguration.ResultTypeConverters.AddOrReplace(mockServiceResultTypeConverter.Object);
        }
    }
}

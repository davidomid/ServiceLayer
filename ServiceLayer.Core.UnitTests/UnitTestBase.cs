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
            //Mock<FromResultTypeConverter<ResultTypes>> mockServiceResultTypeConverter = new Mock<FromResultTypeConverter<ResultTypes>>();
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<HttpStatusCode>(It.IsAny<ResultTypes>()))
            //    .Returns(HttpStatusCode.Ok);
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<ResultTypes>(It.IsAny<ResultTypes>()))
            //    .Returns(ResultTypes.Success);

            //ServiceLayerConfiguration.ResultTypeConverters.Add(mockServiceResultTypeConverter.Object);
        }
    }
}

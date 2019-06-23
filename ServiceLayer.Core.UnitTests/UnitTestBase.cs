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
            //Mock<FromResultTypeConverter<ResultType>> mockServiceResultTypeConverter = new Mock<FromResultTypeConverter<ResultType>>();
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<HttpStatusCode>(It.IsAny<ResultType>()))
            //    .Returns(HttpStatusCode.Ok);
            //mockServiceResultTypeConverter.Setup(c =>
            //        c.Convert<ResultType>(It.IsAny<ResultType>()))
            //    .Returns(ResultType.Success);

            //ServiceLayerConfiguration.ResultTypeConverters.Add(mockServiceResultTypeConverter.Object);
        }
    }
}

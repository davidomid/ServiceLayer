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
            //Mock<FromResultTypeConverter<ResultType>> mockResultTypeConverter = new Mock<FromResultTypeConverter<ResultType>>();
            //mockResultTypeConverter.Setup(c =>
            //        c.Convert<HttpStatusCode>(It.IsAny<ResultType>()))
            //    .Returns(HttpStatusCode.Ok);
            //mockResultTypeConverter.Setup(c =>
            //        c.Convert<ResultType>(It.IsAny<ResultType>()))
            //    .Returns(ResultType.Success);

            //ServiceLayerConfiguration.ResultTypeConverters.Add(mockResultTypeConverter.Object);
        }
    }
}

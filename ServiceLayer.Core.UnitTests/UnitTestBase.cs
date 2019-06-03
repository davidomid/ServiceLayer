using Moq;
using NUnit.Framework;
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
            SetupMockResultTypeConversionService();
        }

        private static void SetupMockResultTypeConversionService()
        {
            //MockResultTypeConversionService.Setup(s =>
            //s.Convert<HttpServiceResultTypes>(ServiceResultTypes.Success))
            //.Returns(HttpServiceResultTypes.Ok);
            //MockResultTypeConversionService.Setup(s =>
            //s.Convert<ServiceResultTypes>(HttpServiceResultTypes.Ok))
            //.Returns(ServiceResultTypes.Success);
        }
    }
}

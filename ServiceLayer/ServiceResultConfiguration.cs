using ServiceLayer.Converters;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Converters;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer
{
    public static class ServiceResultConfiguration
    {
        static ServiceResultConfiguration()
        {
            ResultTypeConverters.General.AddOrReplace(new GeneralServiceResultTypesConverter());
        }

        public static IResultTypeConverterCollection ResultTypeConverters { get; } = new ResultTypeConverterCollection();

        internal static IServiceResultFactory ServiceResultFactory => ServiceLocator.Instance.Resolve<IServiceResultFactory>();

        internal static IDataServiceResultFactory DataServiceResultFactory =>
            ServiceLocator.Instance.Resolve<IDataServiceResultFactory>();

        internal static ISuccessResultFactory SuccessResultFactory =>
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =>
            ServiceLocator.Instance.Resolve<IFailureResultFactory>();
    }
}

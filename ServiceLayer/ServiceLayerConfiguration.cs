using ServiceLayer.Converters;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Converters;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;

namespace ServiceLayer
{
    public static class ServiceLayerConfiguration
    {
        public static IResultTypeConverterCollection ResultTypeConverters { get; } = new ResultTypeConverterCollection();

        internal static IResultTypeConversionService ResultTypeConversionService => ServiceLocator.Instance.Resolve<IResultTypeConversionService>();

        internal static IServiceResultFactory ServiceResultFactory => ServiceLocator.Instance.Resolve<IServiceResultFactory>();

        internal static IDataServiceResultFactory DataServiceResultFactory =>
            ServiceLocator.Instance.Resolve<IDataServiceResultFactory>();

        internal static ISuccessResultFactory SuccessResultFactory =>
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =>
            ServiceLocator.Instance.Resolve<IFailureResultFactory>();
    }
}

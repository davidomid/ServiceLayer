using ServiceLayer.Internal.Converters;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Plugins;
using ServiceLayer.Internal.Services;

namespace ServiceLayer.Internal
{
    internal static class Engine
    {
        internal static IResultTypeConverterCollection ResultTypeConverters { get; } = new ResultTypeConverterCollection();

        internal static IPluginCollection Plugins { get; } = new PluginCollection();

        internal static IResultTypeConversionService ResultTypeConversionService => ServiceLocator.Instance.Resolve<IResultTypeConversionService>();

        internal static IResultFactory ResultFactory => ServiceLocator.Instance.Resolve<IResultFactory>();

        internal static IDataResultFactory DataResultFactory =>
            ServiceLocator.Instance.Resolve<IDataResultFactory>();

        internal static ISuccessResultFactory SuccessResultFactory =>
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =>
            ServiceLocator.Instance.Resolve<IFailureResultFactory>();
    }
}

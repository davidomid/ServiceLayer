using ServiceLayer.Converters;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    public static class ServiceLayer
    {
        static ServiceLayer()
        {
            ResultTypeConverters = new ResultTypeConverterCollection();
        }

        public static IResultTypeConverterCollection ResultTypeConverters { get; }
    }
}

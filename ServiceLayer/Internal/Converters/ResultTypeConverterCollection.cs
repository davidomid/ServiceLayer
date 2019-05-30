using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        public ISpecificResultTypeConverterCollection ConvertToFromSpecific { get; } = new SpecificResultTypeConverterCollection();
        public IConvertToResultTypeConverterCollection ConvertToFromAny { get; } = new ConvertToResultTypeConverterCollection();
        public IConvertFromResultTypeConverterCollection ConvertFromToAny { get; } = new ConvertFromResultTypeConverterCollection();
    }
}

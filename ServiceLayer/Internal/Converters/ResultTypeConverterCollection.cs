using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        public IGeneralResultTypeConverterCollection General { get; } = new GeneralResultTypeConverterCollection();
        public ISpecificResultTypeConverterCollection Specific { get; } = new SpecificResultTypeConverterCollection();
    }
}

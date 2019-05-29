namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        IGeneralResultTypeConverterCollection General { get; }
        ISpecificResultTypeConverterCollection Specific { get; }
    }
}

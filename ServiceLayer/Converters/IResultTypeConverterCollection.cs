namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        ISpecificResultTypeConverterCollection ConvertToFromSpecific { get; }
        IConvertToResultTypeConverterCollection ConvertToFromAny { get; }
        IConvertFromResultTypeConverterCollection ConvertFromToAny { get; }
    }
}

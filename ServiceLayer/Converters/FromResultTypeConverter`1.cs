using System;
namespace ServiceLayer.Converters
{
    public abstract class FromResultTypeConverter<TSourceResultType> : ResultTypeConverter, IFromResultTypeConverter<TSourceResultType> where TSourceResultType : struct, Enum
    {
        protected FromResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }

        Enum IResultTypeConverter.Convert(Enum sourceResultType)
        {
            return base.Convert(sourceResultType) ?? Convert(sourceResultType);
        }

        public abstract Enum Convert(TSourceResultType sourceResultType);
    }
}

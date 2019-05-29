using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IGeneralResultTypeConverterCollection
    {
        IReadOnlyCollection<IResultTypeConverter> GetAll();
        IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : struct, Enum;
        void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : struct, Enum;
        void Remove<TDestinationResultType>() where TDestinationResultType : Enum;
    }
}

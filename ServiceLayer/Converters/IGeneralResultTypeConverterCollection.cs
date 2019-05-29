using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IGeneralResultTypeConverterCollection
    {
        IReadOnlyCollection<IResultTypeConverter> GetAll();
        IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : Enum;
        void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : Enum;
        void Remove<TDestinationResultType>() where TDestinationResultType : Enum;
    }
}

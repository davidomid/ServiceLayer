using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<IResultTypeConverter> GetAll();
        IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : Enum;
        IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum;

        void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : Enum;
        void AddOrReplace<TSourceResultType, TDestinationResultType>(IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : Enum where TDestinationResultType : Enum;

        void Remove<TDestinationResultType>() where TDestinationResultType : Enum;
        void Remove<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum;
    }
}

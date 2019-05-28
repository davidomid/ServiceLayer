using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<IResultTypeConverter> GetAll();

        IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum;

        void AddOrReplace<TSourceResultType, TDestinationResultType>(
            IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : Enum where TDestinationResultType : Enum;

        void Remove<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum;
    }
}

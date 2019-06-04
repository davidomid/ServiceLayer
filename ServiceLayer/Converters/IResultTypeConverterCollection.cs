using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<ResultTypeConverter> GetAll();
        ResultTypeConverter Get(Type sourceResultType, Type destinationResultType);
        void AddOrReplace(ResultTypeConverter resultTypeConverter);
        void Remove(ResultTypeConverter resultTypeConverter);
    }
}

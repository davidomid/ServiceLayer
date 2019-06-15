using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<ResultTypeConverter> GetAll();
        ResultTypeConverter Get(Type sourceResultType, Type destinationResultType);
        void Add(ResultTypeConverter resultTypeConverter);
        void Remove(ResultTypeConverter resultTypeConverter);
    }
}

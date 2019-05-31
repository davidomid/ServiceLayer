using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<IResultTypeConverter> GetAll();
        IResultTypeConverter Get(Type sourceResultType, Type destinationResultType);
        void AddOrReplace(IResultTypeConverter resultTypeConverter);
        void Remove(IResultTypeConverter resultTypeConverter);
    }
}

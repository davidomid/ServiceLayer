using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface ISpecificResultTypeConverterCollection
    {
        IReadOnlyCollection<IConvertToResultType<,>> GetAll();
    }
}

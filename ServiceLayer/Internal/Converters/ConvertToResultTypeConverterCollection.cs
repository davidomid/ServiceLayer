using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ConvertToResultTypeConverterCollection : IConvertToResultTypeConverterCollection
    {
        private readonly Dictionary<Type, IConvertToResultType> _generalConverters =
            new Dictionary<Type, IConvertToResultType>();

        public IReadOnlyCollection<IConvertToResultType> GetAll()
        {
            return new ReadOnlyCollection<IConvertToResultType>(_generalConverters.Values.ToList());
        }

        public IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : struct, Enum
        {
            if(_generalConverters.TryGetValue(typeof(TDestinationResultType), out var converter))
            {
                return converter as IResultTypeConverter<TDestinationResultType>;
            }
            return null;
        }

        public void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : struct, Enum
        {
            _generalConverters[typeof(TDestinationResultType)] = resultTypeConverter;
        }

        public void Remove<TDestinationResultType>() where TDestinationResultType : Enum
        {
            _generalConverters.Remove(typeof(TDestinationResultType));
        }

    }
}

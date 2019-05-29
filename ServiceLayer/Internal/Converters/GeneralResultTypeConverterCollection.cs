using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class GeneralResultTypeConverterCollection : IGeneralResultTypeConverterCollection
    {
        private readonly Dictionary<Type, IResultTypeConverter> _generalConverters =
            new Dictionary<Type, IResultTypeConverter>();

        public IReadOnlyCollection<IResultTypeConverter> GetAll()
        {
            return new ReadOnlyCollection<IResultTypeConverter>(_generalConverters.Values.ToList());
        }

        public IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : Enum
        {
            if(_generalConverters.TryGetValue(typeof(TDestinationResultType), out var converter))
            {
                return converter as IResultTypeConverter<TDestinationResultType>;
            }
            return null;
        }

        public void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : Enum
        {
            _generalConverters[typeof(TDestinationResultType)] = resultTypeConverter;
        }

        public void Remove<TDestinationResultType>() where TDestinationResultType : Enum
        {
            _generalConverters.Remove(typeof(TDestinationResultType));
        }

    }
}

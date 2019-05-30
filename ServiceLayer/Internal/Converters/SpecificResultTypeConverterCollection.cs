using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class SpecificResultTypeConverterCollection : ISpecificResultTypeConverterCollection
    {
        private readonly Dictionary<Type, Dictionary<Type, IConvertToResultType>> _specificConverters = new Dictionary<Type, Dictionary<Type, IConvertToResultType>>();

        public IReadOnlyCollection<IConvertToResultType> GetAll()
        {
            return new ReadOnlyCollection<IConvertToResultType>(_specificConverters.SelectMany(sc => sc.Value.Values).ToList());
        }

        public IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>(Type sourceResultType) where TDestinationResultType : struct, Enum
        {
            if (_specificConverters.TryGetValue(typeof(TDestinationResultType), out var converterDictionary))
            {
                if (converterDictionary.TryGetValue(sourceResultType, out var converter))
                {
                    return converter as IResultTypeConverter<TDestinationResultType>;
                }
            }

            return null;
        }

        public IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : struct, Enum where TDestinationResultType : struct, Enum
        {
            return this.Get<TDestinationResultType>(typeof(TSourceResultType)) as IResultTypeConverter<TSourceResultType, TDestinationResultType>;
        }

        public void AddOrReplace<TSourceResultType, TDestinationResultType>(IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : struct, Enum where TDestinationResultType : struct, Enum
        {
            if (!_specificConverters.ContainsKey(typeof(TDestinationResultType)))
            {
                _specificConverters[typeof(TDestinationResultType)] = new Dictionary<Type, IConvertToResultType>();
            }
            _specificConverters[typeof(TDestinationResultType)][typeof(TSourceResultType)] = resultTypeConverter;
        }

        public void Remove<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            if (_specificConverters.ContainsKey(typeof(TDestinationResultType)))
            {
                _specificConverters[typeof(TDestinationResultType)].Remove(typeof(TSourceResultType));
            }
        }
    }
}

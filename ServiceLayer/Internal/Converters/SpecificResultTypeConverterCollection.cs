﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class SpecificResultTypeConverterCollection : ISpecificResultTypeConverterCollection
    {
        private readonly Dictionary<Type, Dictionary<Type, IResultTypeConverter>> _specificConverters = new Dictionary<Type, Dictionary<Type, IResultTypeConverter>>();

        public IReadOnlyCollection<IResultTypeConverter> GetAll()
        {
            return new ReadOnlyCollection<IResultTypeConverter>(_specificConverters.SelectMany(sc => sc.Value.Values).ToList());
        }

        public IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>(Type sourceResultType) where TDestinationResultType : Enum
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

        public IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            return this.Get<TDestinationResultType>(typeof(TSourceResultType)) as IResultTypeConverter<TSourceResultType, TDestinationResultType>;
        }

        public void AddOrReplace<TSourceResultType, TDestinationResultType>(IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : Enum where TDestinationResultType : Enum
        {
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

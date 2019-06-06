using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        private readonly List<ResultTypeConverter> _resultTypeConverters = new List<ResultTypeConverter>
        {
            new DefaultResultTypeConverter()
        };

        public IReadOnlyCollection<ResultTypeConverter> GetAll()
        {
            return new ReadOnlyCollection<ResultTypeConverter>(_resultTypeConverters);
        }

        public ResultTypeConverter Get(Type sourceResultType, Type destinationResultType)
        {
            return _resultTypeConverters.FirstOrDefault(c => c.SourceType == sourceResultType && c.DestinationType == destinationResultType);
        }

        public void AddOrReplace(ResultTypeConverter resultTypeConverter)
        {
            if (_resultTypeConverters.Contains(resultTypeConverter))
            {
                return;
            }

            ResultTypeConverter existingResultTypeConverter = Get(resultTypeConverter.SourceType, resultTypeConverter.DestinationType);
            if (existingResultTypeConverter != null)
            {
                Remove(existingResultTypeConverter);
            }
            _resultTypeConverters.Add(resultTypeConverter);
        }

        public void Remove(ResultTypeConverter resultTypeConverter)
        {
            _resultTypeConverters.Remove(resultTypeConverter);
        }
    }
}

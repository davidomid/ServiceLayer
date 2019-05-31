using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        private readonly List<IResultTypeConverter> _resultTypeConverters = new List<IResultTypeConverter>();

        public IReadOnlyCollection<IResultTypeConverter> GetAll()
        {
            return new ReadOnlyCollection<IResultTypeConverter>(_resultTypeConverters);
        }

        public IResultTypeConverter Get(Type sourceResultType, Type destinationResultType)
        {
            return _resultTypeConverters.FirstOrDefault(c => c.SourceType == sourceResultType && c.DestinationType == destinationResultType);
        }

        public void AddOrReplace(IResultTypeConverter resultTypeConverter)
        {
            if (_resultTypeConverters.Contains(resultTypeConverter))
            {
                return;
            }

            IResultTypeConverter existingResultTypeConverter = Get(resultTypeConverter.SourceType, resultTypeConverter.DestinationType);
            if (existingResultTypeConverter != null)
            {
                Remove(existingResultTypeConverter);
            }
            _resultTypeConverters.Add(resultTypeConverter);
        }

        public void Remove(IResultTypeConverter resultTypeConverter)
        {
            _resultTypeConverters.Remove(resultTypeConverter);
        }
    }
}

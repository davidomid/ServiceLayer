using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        private readonly HashSet<ResultTypeConverter> _resultTypeConverters = new HashSet<ResultTypeConverter>
        {
            new AttributeResultTypeConverter()
        };

        public IReadOnlyCollection<ResultTypeConverter> GetAll()
        {
            return new ReadOnlyCollection<ResultTypeConverter>(_resultTypeConverters.ToList());
        }

        public ResultTypeConverter Get(Type sourceResultType, Type destinationResultType)
        {
            return _resultTypeConverters.FirstOrDefault(c => c.SourceType == sourceResultType && c.DestinationType == destinationResultType);
        }

        public void Add(ResultTypeConverter resultTypeConverter)
        {
            ResultTypeConverter existingResultTypeConverter = Get(resultTypeConverter.SourceType, resultTypeConverter.DestinationType);
            if (existingResultTypeConverter != null)
            {
                string sourceTypeName = resultTypeConverter.SourceType.ToString() ?? "any";
                string destinationTypeName = resultTypeConverter.DestinationType.ToString() ?? "any";
                throw new InvalidOperationException("A result type converter already exists for converting between the following types:\n" +
                                                    $"Source: {sourceTypeName}\n" +
                                                    $"Destination: {destinationTypeName}.\n" +
                                                    "If you are intending to replace a converter, you will need to remove the old one before adding the new one.");
            }
            _resultTypeConverters.Add(resultTypeConverter);
        }

        public void Remove(ResultTypeConverter resultTypeConverter)
        {
            _resultTypeConverters.Remove(resultTypeConverter);
        }
    }
}

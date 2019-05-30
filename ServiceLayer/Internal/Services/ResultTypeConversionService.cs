using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Services
{
    internal class ResultTypeConversionService : IResultTypeConversionService
    {
        // The following algorithm should be used for conversion:
        // Check if there is a particular rule setup for converting from TSourceResultType to TDestinationSourceResultType
        // If there is, use it.
        // If there isn't, check if there is a general rule for converting from TSourceResultType to any Enum in general.
        // If there is, use it.
        // If there isn't, check if there is a rule for converting to TDestinationSourceResultType from any Enum in general.
        // If there is, use it.
        // Otherwise, throw exception.
        // If the rule itself fails, we throw another exception.

        private readonly List<IResultTypeConverter> _resultTypeConverters = new List<IResultTypeConverter>();

        public TDestinationResultType Convert<TSourceResultType, TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum
        {
            IResultTypeConverter 
        }
    }
}

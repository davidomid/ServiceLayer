using System;

namespace ServiceLayer.Converters
{
    internal interface IResultTypeConverter
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        Enum Convert(Enum sourceResultType, Type destinationType); 
    }
}

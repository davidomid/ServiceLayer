using System;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        Enum Convert(Enum sourceResultType);
    }
}

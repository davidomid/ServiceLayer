using System;

namespace ServiceLayer.Converters
{
    internal interface IResultTypeConverter
    {
        Enum Convert(Enum sourceResultType, Type destinationType); 
    }
}

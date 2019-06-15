using System;

namespace ServiceLayer
{
    internal interface IResultTypeConverter
    {
        Enum Convert(Enum sourceResultType, Type destinationType); 
    }
}

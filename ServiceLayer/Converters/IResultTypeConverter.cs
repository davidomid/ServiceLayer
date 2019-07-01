using System;

namespace ServiceLayer
{
    internal interface IResultTypeConverter
    {
        Enum PerformInternalConversion(Enum sourceResultType, Type destinationType); 
    }
}

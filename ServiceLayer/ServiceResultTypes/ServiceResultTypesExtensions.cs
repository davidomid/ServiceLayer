using System;
namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static ServiceResultTypes ToServiceResultType(this Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            if (enumType == typeof(ServiceResultTypes))
            {
                return (ServiceResultTypes) enumValue;
            }

            // todo get attributes of the enum
            // todo find Success attribute and return success if found
            // todo otherwise return failure
            return ServiceResultTypes.Failure; 
        }
    }
}

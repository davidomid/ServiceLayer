using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ToServiceResultTypesConverter : ToResultTypeConverter<ServiceResultTypes>
    {
        public override ServiceResultTypes Convert(Enum sourceResultType)
        {
            Type sourceType = sourceResultType.GetType();

            // We consider an enum value to represent a ServiceResultTypes.Success if the value has been tagged with a SuccessAttribute. 
            // Otherwise, it represents ServiceResultTypes.Failure.
            var name = Enum.GetName(sourceType, sourceResultType);
            var successAttribute = sourceType.GetTypeInfo().DeclaredFields
                .FirstOrDefault(p => p.Name == name)?
                .GetCustomAttributes<ResultTypeAttribute>(false)
                .FirstOrDefault(a => a.ResultType.Equals(ServiceResultTypes.Success));

            if (successAttribute != null)
            {
                return ServiceResultTypes.Success;
            }

            return ServiceResultTypes.Failure;
        }
    }
}

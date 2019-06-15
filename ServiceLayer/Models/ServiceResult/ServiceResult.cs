﻿using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType) : this(resultType, default)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, object errorDetails)
        {
            ResultType = resultType;
            ErrorDetails = errorDetails;
            IsSuccessful = resultType == ServiceResultTypes.Success;
        }

        public ServiceResultTypes ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful { get; }

        public static implicit operator ServiceResult(ServiceResultTypes serviceResultType)
        {
            return Engine.ServiceResultFactory.Create(serviceResultType);
        }
    }
}
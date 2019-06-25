using System;
using System.Collections.Generic;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;

namespace ServiceLayer.Internal
{
    internal class ServiceLocator : IServiceLocator
    {
        public static IServiceLocator Instance = new ServiceLocator();

        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>
        {
            { typeof(IResultFactory), new ResultFactory() },
            { typeof(IDataResultFactory), new DataResultFactory() },
            { typeof(ISuccessResultFactory), new SuccessResultFactory() },
            { typeof(IFailureResultFactory), new FailureResultFactory() },
            { typeof(IInconclusiveResultFactory), new InconclusiveResultFactory() },
            { typeof(IResultTypeConversionService), new ResultTypeConversionService() }
        };

        public T Resolve<T>() where T : class
        {
            return _instances[typeof(T)] as T;
        }
    }
}

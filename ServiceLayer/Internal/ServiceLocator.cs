using System;
using System.Collections.Generic;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer.Internal
{
    internal class ServiceLocator : IServiceLocator
    {
        public static IServiceLocator Instance = new ServiceLocator();

        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>
        {
            { typeof(IServiceResultFactory), new ServiceResultFactory() },
            { typeof(IDataServiceResultFactory), new DataServiceResultFactory() },
            { typeof(ISuccessResultFactory), new SuccessResultFactory() },
            { typeof(IFailureResultFactory), new FailureResultFactory() }
        };

        public T Resolve<T>() where T : class
        {
            return _instances[typeof(T)] as T;
        }
    }
}

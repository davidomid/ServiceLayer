using System;
using System.Collections.Generic;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core.Internal
{
    internal class ServiceLocator : IServiceLocator
    {
        public static IServiceLocator Instance = new ServiceLocator();
        private ServiceLocator()
        {
        }

        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>
        {
            { typeof(IActionResultFactory), new ActionResultFactory() }
        };

        public T Resolve<T>() where T : class
        {
            return _instances[typeof(T)] as T;
        }
    }
}

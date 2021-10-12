using System;
using System.Collections.Generic;

namespace ServiceLayer.Core.Internal
{
    internal class ServiceLocator : IServiceLocator
    {
        public static IServiceLocator Instance = new ServiceLocator();
        private ServiceLocator()
        {
        }

        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Register<T>(T component) where T : class
        {
            _instances[typeof(T)] = component;
        }

        public T Resolve<T>() where T : class
        {
            if (_instances.ContainsKey(typeof(T)))
            {
                return _instances[typeof(T)] as T;
            }
            return null;
        }
    }
}

﻿namespace ServiceLayer.Internal
{
    internal class ServiceLocator : IServiceLocator
    {
        public static ServiceLocator Instance = new ServiceLocator();

        public T Resolve<T>() where T : class
        {
            if (typeof(T) == typeof(IServiceResultFactory))
            {
                return new ServiceResultFactory() as T;
            }
            if (typeof(T) == typeof(IDataServiceResultFactory))
            {
                return new DataServiceResultFactory() as T;
            }
            return null;
        }
    }
}
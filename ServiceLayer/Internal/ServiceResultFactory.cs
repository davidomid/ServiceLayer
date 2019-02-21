namespace ServiceLayer.Internal
{
    internal class ServiceResultFactory : IServiceResultFactory
    {
        public ServiceResult Create(ServiceResultTypes serviceResultType)
        {
            return new ServiceResult(serviceResultType);
        }
    }
}

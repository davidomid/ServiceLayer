namespace ServiceLayer.Internal
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
    }
}

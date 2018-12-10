namespace ServiceLayer
{
    public interface IServiceResult<out TData> : IServiceResult, IGenericServiceResult<ServiceResultTypes, TData>
    {
    }
}

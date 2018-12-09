namespace ServiceLayer
{
    public interface IServiceResult<out TData> : IServiceResult, IBaseServiceResult<ServiceResultTypes, TData>
    {
    }
}

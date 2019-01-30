namespace ServiceLayer
{
    public interface IDataServiceResult<out TData> : IDataServiceResult<TData, ServiceResultTypes>
    {
        
    }
}

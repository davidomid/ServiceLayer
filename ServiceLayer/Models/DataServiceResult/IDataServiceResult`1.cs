namespace ServiceLayer
{
    public interface IDataServiceResult<out TData> : IServiceResult
    {
        TData Data { get; }
    }
}

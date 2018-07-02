namespace ServiceLayer.Results
{
    public interface IServiceResult<out T> : IServiceResult
    {
        T Data { get; }
    }
}
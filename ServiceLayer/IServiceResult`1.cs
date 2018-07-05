namespace ServiceLayer
{
    public interface IServiceResult<out T> : IServiceResult
    {
        T Data { get; }
    }
}
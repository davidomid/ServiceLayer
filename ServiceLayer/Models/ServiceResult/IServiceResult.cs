namespace ServiceLayer
{
    public interface IServiceResult
    {
        ServiceResultTypes ResultType { get; }

        object ErrorDetails { get; }

        bool IsSuccessful { get; }
    }
}

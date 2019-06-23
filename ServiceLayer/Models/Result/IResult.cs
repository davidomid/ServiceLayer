namespace ServiceLayer
{
    public interface IResult
    {
        ResultTypes ResultType { get; }

        object ErrorDetails { get; }

        bool IsSuccessful { get; }
    }
}

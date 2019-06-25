namespace ServiceLayer
{
    public interface IResult
    {
        ResultType ResultType { get; }

        object ErrorDetails { get; }

        bool IsSuccessful { get; }
    }
}

namespace ServiceLayer
{
    public interface IResult
    {
        ResultType ResultType { get; }
        bool IsSuccessful { get; }
    }
}

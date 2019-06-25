namespace ServiceLayer
{
    public interface IDataResult<out TData> : IResult
    {
        TData Data { get; }
    }
}

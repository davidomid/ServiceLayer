using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Result : IResult
    {
        public Result(ResultType resultType)
        {
            ResultType = resultType;
            IsSuccessful = resultType == ResultType.Success;
        }

        public ResultType ResultType { get; }
        public bool IsSuccessful { get; }

        public static implicit operator Result(ResultType resultType)
        {
            return Engine.ResultFactory.Create(resultType);
        }
    }
}
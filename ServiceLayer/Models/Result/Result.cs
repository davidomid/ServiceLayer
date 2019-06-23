using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Result : IResult
    {
        public Result(ResultType resultType) : this(resultType, default)
        {
        }

        public Result(ResultType resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public Result(ResultType resultType, object errorDetails)
        {
            ResultType = resultType;
            ErrorDetails = errorDetails;
            IsSuccessful = resultType == ServiceLayer.ResultType.Success;
        }

        public ResultType ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful { get; }

        public static implicit operator Result(ResultType resultType)
        {
            return Engine.ResultFactory.Create(resultType);
        }
    }
}
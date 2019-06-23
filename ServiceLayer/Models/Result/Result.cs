using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Result : IResult
    {
        public Result(ResultTypes resultType) : this(resultType, default)
        {
        }

        public Result(ResultTypes resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public Result(ResultTypes resultType, object errorDetails)
        {
            ResultType = resultType;
            ErrorDetails = errorDetails;
            IsSuccessful = resultType == ResultTypes.Success;
        }

        public ResultTypes ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful { get; }

        public static implicit operator Result(ResultTypes resultType)
        {
            return Engine.ServiceResultFactory.Create(resultType);
        }
    }
}
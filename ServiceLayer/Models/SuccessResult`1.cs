namespace ServiceLayer
{
    public class SuccessResult<TData> : DataServiceResult<TData, ServiceResultTypes, object>
    {
        //public static implicit operator DataServiceResult<TData>(SuccessResult<TData> successResult)
        //{
        //    return new DataServiceResult<TData, ServiceResultTypes>(successResult.Data, successResult.ResultType);
        //}

        //public static implicit operator SuccessResult<TData>(TData data)
        //{
        //    return new SuccessResult<TData>(data);
        //}
        public SuccessResult(TData data) : base(data, ServiceResultTypes.Success)
        {
        }
    }
}

using ServiceLayer.Attributes;

namespace ServiceLayer.Core
{
    public enum HttpServiceResultTypes
    {
        [Success]
        Ok,
        [Failure]
        BadRequest, 
        [ResultType(ServiceResultTypes.Failure)]
        NotFound,
        Forbidden,
        Unauthorized,
        Conflict,
        [Failure(IsDefault = true)]
        InternalServerError
    }
}
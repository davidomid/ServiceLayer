using ServiceLayer.Attributes;

namespace ServiceLayer.Core
{
    public enum HttpServiceResultTypes
    {
        [Success]
        Ok,
        BadRequest, 
        NotFound,
        Forbidden,
        Unauthorized,
        Conflict,
        [Failure(IsDefault = true)]
        InternalServerError
    }
}
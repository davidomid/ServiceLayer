using ServiceLayer.Attributes;

namespace ServiceLayer
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
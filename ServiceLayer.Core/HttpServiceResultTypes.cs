namespace ServiceLayer
{
    public enum HttpServiceResultTypes
    {
        Ok,
        BadRequest, 
        NotFound,
        Forbidden,
        Unauthorized,
        Conflict,
        InternalServerError
    }
}
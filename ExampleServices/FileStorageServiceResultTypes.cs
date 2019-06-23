﻿using System.Net;
using ServiceLayer;
namespace ExampleServices
{
    public enum FileStorageServiceResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        Failure,
        [ResultType(ResultTypes.Failure)]
        [ResultType(HttpStatusCode.BadRequest)]
        FilePathNotExists
    }
}

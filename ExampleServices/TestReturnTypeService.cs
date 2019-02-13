using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer;

namespace ExampleServices
{
    public class TestReturnTypeService : IService
    {
        public ServiceResult Test1()
        {
            return new ServiceResult(ServiceResultTypes.Success);
        }
        public ServiceResult Test2()
        {
            return new ServiceResult(ServiceResultTypes.Failure);
        }
        public ServiceResult Test3()
        {
            return new SuccessResult();
        }
        public ServiceResult Test4()
        {
            return new FailureResult();
        }

        public ServiceResult<FileStorageServiceResultTypes> Test5()
        {
            return new ServiceResult<FileStorageServiceResultTypes>(FileStorageServiceResultTypes.Success);
        }
        public ServiceResult<FileStorageServiceResultTypes> Test6()
        {
            return this.Result(FileStorageServiceResultTypes.Success); 
        }
        public ServiceResult<FileStorageServiceResultTypes> Test7()
        {
            return new SuccessResult();
        }
        public ServiceResult<FileStorageServiceResultTypes> Test8()
        {
            return this.Success();
        }
    }
}

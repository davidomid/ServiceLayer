using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer;

namespace ExampleServices
{
    public class TestReturnTypeService : IService
    {
        public ServiceResult TestA1()
        {
            return new ServiceResult(ServiceResultTypes.Success);
        }
        public ServiceResult TestA2()
        {
            return new ServiceResult(ServiceResultTypes.Failure);
        }
        public ServiceResult TestA3()
        {
            return new SuccessResult();
        }
        public ServiceResult TestA4()
        {
            return new FailureResult();
        }
        public ServiceResult TestA5()
        {
            return ServiceResultTypes.Success;
        }
        public ServiceResult TestA6()
        {
            return ServiceResultTypes.Failure;
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
        public ServiceResult<FileStorageServiceResultTypes> Test9()
        {
            return this.Failure("test"); 
        }
        public ServiceResult<FileStorageServiceResultTypes> Test10()
        {
            return this.Failure("test", 100, 200);
        }
        public ServiceResult<FileStorageServiceResultTypes> Test11()
        {
            return FileStorageServiceResultTypes.Success;
        }
        public ServiceResult<FileStorageServiceResultTypes> Test12()
        {
            return this.Result(FileStorageServiceResultTypes.Success);
        }
    }
}

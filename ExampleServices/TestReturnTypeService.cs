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
            return new SuccessResult();
        }

        public ServiceResult TestA2()
        {
            return new ServiceResult(ServiceResultTypes.Success);
        }

        public ServiceResult TestA3()
        {
            return this.Result(ServiceResultTypes.Success);
        }

        public ServiceResult TestA4()
        {
            return ServiceResultTypes.Success;
        }

        public ServiceResult TestA5()
        {
            return new FailureResult();
        }

        public ServiceResult TestA6()
        {
            return new ServiceResult(ServiceResultTypes.Failure);
        }

        public ServiceResult TestA7()
        {
            return ServiceResultTypes.Failure;
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB1()
        {
            return new SuccessResult();
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB2()
        {
            return this.Result(FileStorageServiceResultTypes.Success); 
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB3()
        {
            return FileStorageServiceResultTypes.Success;
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB4()
        {
            return new ServiceResult<FileStorageServiceResultTypes>(FileStorageServiceResultTypes.Success);
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB5()
        {
            return this.Success();
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB6()
        {
            return this.Failure("test");
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB7()
        {
            return this.Failure("test", 100, 200);
        }

        public ServiceResult<FileStorageServiceResultTypes> TestB8()
        {
            return this.Result(FileStorageServiceResultTypes.Success);
        }

        public ServiceResult<ServiceResultTypes, string> TestC1()
        {
            return this.Success();
        }
        public ServiceResult<ServiceResultTypes, string> TestC2()
        {
            return new FailureResult<string>("test error");
        }
        public ServiceResult<ServiceResultTypes, string> TestC3()
        {
            return this.Failure("test error");
        }
        public ServiceResult<ServiceResultTypes, string> TestC4()
        {
            return "test error";
        }

        public DataServiceResult<int, FileStorageServiceResultTypes> TestF1()
        {
            return this.Success(100); 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestF2()
        {
            return 100; 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestF3()
        {
            return this.Failure(); 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestF4()
        {
            return this.Failure("test1");
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestF5()
        {
            return this.Failure("test1", "test2", "test3");
        }
    }
}

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
        public ServiceResult TestA8()
        {
            // todo reconsider this 
            return this.Result(FileStorageServiceResultTypes.Success); 
        }
        public ServiceResult TestA9()
        {
            // todo reconsider this 
            return this.DataResult(100, ServiceResultTypes.Success);
        }

        public ServiceResult<ServiceResultTypes> TestB1()
        {
            return new SuccessResult();
        }

        public ServiceResult<ServiceResultTypes> TestB2()
        {
            return new ServiceResult(ServiceResultTypes.Success);
        }

        public ServiceResult<ServiceResultTypes> TestB3()
        {
            return this.Result(ServiceResultTypes.Success);
        }

        public ServiceResult<ServiceResultTypes> TestB4()
        {
            return ServiceResultTypes.Success;
        }

        public ServiceResult<ServiceResultTypes> TestB5()
        {
            return new FailureResult();
        }

        public ServiceResult<ServiceResultTypes> TestB6()
        {
            return new ServiceResult(ServiceResultTypes.Failure);
        }

        public ServiceResult<ServiceResultTypes> TestB7()
        {
            return ServiceResultTypes.Failure;
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC1()
        {
            return new SuccessResult();
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC2()
        {
            return this.Result(FileStorageServiceResultTypes.Success); 
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC3()
        {
            return FileStorageServiceResultTypes.Success;
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC4()
        {
            return new ServiceResult<FileStorageServiceResultTypes>(FileStorageServiceResultTypes.Success);
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC5()
        {
            return this.Success();
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC6()
        {
            return this.Failure("test");
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC7()
        {
            return this.Failure("test", 100, 200);
        }

        public ServiceResult<FileStorageServiceResultTypes> TestC8()
        {
            return this.Result(FileStorageServiceResultTypes.Success);
        }

        public ServiceResult<ServiceResultTypes, string> TestD1()
        {
            return this.Success();
        }
        public ServiceResult<ServiceResultTypes, string> TestD2()
        {
            return new FailureResult<string>("test error");
        }
        public ServiceResult<ServiceResultTypes, string> TestD3()
        {
            return this.Failure("test error");
        }
        public ServiceResult<ServiceResultTypes, string> TestD4()
        {
            return "test error";
        }
        public ServiceResult<ServiceResultTypes, string> TestD5()
        {
            return ServiceResultTypes.Success;
        }

        public DataServiceResult<int> TestE1()
        {
            return this.Success(100);
        }
        public DataServiceResult<int> TestE2()
        {
            return 100;
        }
        public DataServiceResult<int> TestE3()
        {
            return this.Failure();
        }
        public DataServiceResult<int> TestE4()
        {
            return this.Failure("test1");
        }
        public DataServiceResult<int> TestE5()
        {
            return this.Failure("test1", "test2", "test3");
        }
        public DataServiceResult<int> TestE6()
        {
            return ServiceResultTypes.Success;
        }

        public DataServiceResult<int, FileStorageServiceResultTypes> TestG1()
        {
            return this.Success(100); 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestG2()
        {
            return 100; 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestG3()
        {
            return this.Failure(); 
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestG4()
        {
            return this.Failure("test1");
        }
        public DataServiceResult<int, FileStorageServiceResultTypes> TestG5()
        {
            return this.Failure("test1", "test2", "test3");
        }
    }
}

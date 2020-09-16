using ServiceLayer;

namespace ExampleServices
{
    public class TestReturnTypeService : IService
    {
        public Result TestA1()
        {
            return new SuccessResult();
        }

        public Result TestA2()
        {
            return new Result(ResultType.Success);
        }

        public Result TestA3()
        {
            return this.Result(ResultType.Success);
        }

        public Result TestA4()
        {
            return ResultType.Success;
        }

        public Result TestA5()
        {
            return new FailureResult();
        }

        public Result TestA6()
        {
            return new Result(ResultType.Failure);
        }

        public Result TestA7()
        {
            return ResultType.Failure;
        }
        public Result TestA8()
        {
            return this.Result(FileStorageResultTypes.Success); 
        }
        public Result TestA9()
        {
            return this.DataResult(100, ResultType.Success);
        }

        public Result<ResultType> TestB1()
        {
            return new SuccessResult();
        }

        public Result<ResultType> TestB2()
        {
            return new Result<ResultType>(ResultType.Success);
        }

        public Result<ResultType> TestB3()
        {
            return this.Result<ResultType>(ResultType.Success);
        }

        public Result<ResultType> TestB4()
        {
            return ResultType.Success;
        }

        public Result<ResultType> TestB5()
        {
            return new FailureResult();
        }

        public Result<ResultType> TestB6()
        {
            return ResultType.Failure;
        }

        public Result<FileStorageResultTypes> TestC1()
        {
            return new SuccessResult();
        }

        public Result<FileStorageResultTypes> TestC2()
        {
            return this.Result(FileStorageResultTypes.Success); 
        }

        public Result<FileStorageResultTypes> TestC3()
        {
            return FileStorageResultTypes.Success;
        }

        public Result<FileStorageResultTypes> TestC4()
        {
            return new Result<FileStorageResultTypes>(FileStorageResultTypes.Success);
        }

        public Result<FileStorageResultTypes> TestC5()
        {
            return this.Success();
        }

        public Result<FileStorageResultTypes> TestC6()
        {
            return this.Failure("test");
        }

        public Result<FileStorageResultTypes, int> TestC7()
        {
            return this.Failure(123);
        }

        public Result<FileStorageResultTypes> TestC8()
        {
            return this.Result(FileStorageResultTypes.Success);
        }

        public Result<ResultType, string> TestD1()
        {
            return this.Success();
        }
        public Result<ResultType, string> TestD2()
        {
            return new FailureResult<string>("test error");
        }
        public Result<ResultType, string> TestD3()
        {
            return this.Failure("test error");
        }
        public Result<ResultType, string> TestD4()
        {
            return "test error";
        }
        public Result<ResultType, string> TestD5()
        {
            return ResultType.Success;
        }
        public Result<ResultType, string> TestD6()
        {
            return this.Result(ResultType.Failure, "test error");
        }
        public DataResult<int> TestE1()
        {
            return this.Success(100);
        }
        public DataResult<int> TestE2()
        {
            return 100;
        }
        public DataResult<int> TestE3()
        {
            return this.Failure();
        }
        public DataResult<int> TestE4()
        {
            return this.Failure("test1");
        }
        public DataResult<int> TestE5()
        {
            return this.Failure("test1");
        }
        public DataResult<int> TestE6()
        {
            return ResultType.Success;
        }
        public DataResult<int> TestE7()
        {
            return this.DataResult(100); 
        }
        public DataResult<int> TestE8()
        {
            return this.DataResult(100, ResultType.Success);
        }

        public DataResult<int, ResultType> TestF1()
        {
            return this.Success(100);
        }
        public DataResult<int, ResultType> TestF2()
        {
            return 100;
        }
        public DataResult<int, ResultType> TestF3()
        {
            return this.Failure();
        }
        public DataResult<int, ResultType> TestF4()
        {
            return this.Failure("test123");
        }
        public DataResult<int, ResultType, string> TestF5()
        {
            return this.Failure("test123");
        }

        public DataResult<int, FileStorageResultTypes> TestG1()
        {
            return this.Success(100); 
        }
        public DataResult<int, FileStorageResultTypes> TestG2()
        {
            return 100; 
        }
        public DataResult<int, FileStorageResultTypes> TestG3()
        {
            return this.Failure(); 
        }
        public DataResult<int, FileStorageResultTypes> TestG4()
        {
            return this.Failure("test123");
        }
        public DataResult<int, FileStorageResultTypes, string> TestG5()
        {
            return this.Failure("test123");
        }
        public DataResult<int, FileStorageResultTypes> TestG6()
        {
            return FileStorageResultTypes.FilePathNotExists;
        }
        public DataResult<int, FileStorageResultTypes, string> TestG7()
        {
            return this.Result(FileStorageResultTypes.FilePathNotExists, "The specified file path does not exist");
        }

        public DataResult<int, FileStorageResultTypes, string> TestH1()
        {
            return this.Success(100);
        }
        public DataResult<int, FileStorageResultTypes, string> TestH2()
        {
            return 100;
        }
        public DataResult<int, FileStorageResultTypes, string> TestH3()
        {
            return this.Failure("test1");
        }
        public DataResult<int, FileStorageResultTypes, string> TestH4()
        {
            return "test 1"; 
        }
        public DataResult<int, FileStorageResultTypes, string> TestH5()
        {
            return new FailureResult<string>("test");
        }
        public DataResult<int, FileStorageResultTypes, string> TestH6()
        {
            return this.DataResult<int, FileStorageResultTypes, string>(100, FileStorageResultTypes.Success); 
        }
        public DataResult<int, FileStorageResultTypes, string> TestH7()
        {
            return this.DataResult<int, FileStorageResultTypes, string>(100);
        }

        public SuccessResult<int> TestJ1()
        {
            return 100;
        }
        public FailureResult<string> TestJ2()
        {
            return "test error";
        }

    }
}

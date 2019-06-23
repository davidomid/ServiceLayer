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
            return this.Result(FileStorageServiceResultTypes.Success); 
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

        public Result<FileStorageServiceResultTypes> TestC1()
        {
            return new SuccessResult();
        }

        public Result<FileStorageServiceResultTypes> TestC2()
        {
            return this.Result(FileStorageServiceResultTypes.Success); 
        }

        public Result<FileStorageServiceResultTypes> TestC3()
        {
            return FileStorageServiceResultTypes.Success;
        }

        public Result<FileStorageServiceResultTypes> TestC4()
        {
            return new Result<FileStorageServiceResultTypes>(FileStorageServiceResultTypes.Success);
        }

        public Result<FileStorageServiceResultTypes> TestC5()
        {
            return this.Success();
        }

        public Result<FileStorageServiceResultTypes> TestC6()
        {
            return this.Failure("test");
        }

        public Result<FileStorageServiceResultTypes> TestC7()
        {
            return this.Failure("test", 100, 200);
        }

        public Result<FileStorageServiceResultTypes> TestC8()
        {
            return this.Result(FileStorageServiceResultTypes.Success);
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
            return this.Failure("test1", "test2", "test3");
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
            return this.Failure("test1");
        }
        public DataResult<int, ResultType> TestF5()
        {
            return this.Failure("test1", "test2", "test3");
        }

        public DataResult<int, FileStorageServiceResultTypes> TestG1()
        {
            return this.Success(100); 
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG2()
        {
            return 100; 
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG3()
        {
            return this.Failure(); 
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG4()
        {
            return this.Failure("test1");
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG5()
        {
            return this.Failure("test1", "test2", "test3");
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG6()
        {
            return FileStorageServiceResultTypes.FilePathNotExists;
        }
        public DataResult<int, FileStorageServiceResultTypes> TestG7()
        {
            return this.Result<FileStorageServiceResultTypes>(FileStorageServiceResultTypes.FilePathNotExists, "The specified file path does not exist");
        }

        public DataResult<int, FileStorageServiceResultTypes, string> TestH1()
        {
            return this.Success(100);
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH2()
        {
            return 100;
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH3()
        {
            return this.Failure("test1");
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH4()
        {
            return "test 1"; 
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH5()
        {
            return new FailureResult<string>("test");
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH6()
        {
            return this.DataResult<int, FileStorageServiceResultTypes, string>(100, FileStorageServiceResultTypes.Success); 
        }
        public DataResult<int, FileStorageServiceResultTypes, string> TestH7()
        {
            return this.DataResult<int, FileStorageServiceResultTypes, string>(100);
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

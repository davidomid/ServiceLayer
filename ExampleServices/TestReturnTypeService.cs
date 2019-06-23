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
            return new Result(ResultTypes.Success);
        }

        public Result TestA3()
        {
            return this.Result(ResultTypes.Success);
        }

        public Result TestA4()
        {
            return ResultTypes.Success;
        }

        public Result TestA5()
        {
            return new FailureResult();
        }

        public Result TestA6()
        {
            return new Result(ResultTypes.Failure);
        }

        public Result TestA7()
        {
            return ResultTypes.Failure;
        }
        public Result TestA8()
        {
            return this.Result(FileStorageServiceResultTypes.Success); 
        }
        public Result TestA9()
        {
            return this.DataResult(100, ResultTypes.Success);
        }

        public Result<ResultTypes> TestB1()
        {
            return new SuccessResult();
        }

        public Result<ResultTypes> TestB2()
        {
            return new Result<ResultTypes>(ResultTypes.Success);
        }

        public Result<ResultTypes> TestB3()
        {
            return this.Result<ResultTypes>(ResultTypes.Success);
        }

        public Result<ResultTypes> TestB4()
        {
            return ResultTypes.Success;
        }

        public Result<ResultTypes> TestB5()
        {
            return new FailureResult();
        }

        public Result<ResultTypes> TestB6()
        {
            return ResultTypes.Failure;
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

        public Result<ResultTypes, string> TestD1()
        {
            return this.Success();
        }
        public Result<ResultTypes, string> TestD2()
        {
            return new FailureResult<string>("test error");
        }
        public Result<ResultTypes, string> TestD3()
        {
            return this.Failure("test error");
        }
        public Result<ResultTypes, string> TestD4()
        {
            return "test error";
        }
        public Result<ResultTypes, string> TestD5()
        {
            return ResultTypes.Success;
        }
        public Result<ResultTypes, string> TestD6()
        {
            return this.Result(ResultTypes.Failure, "test error");
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
            return ResultTypes.Success;
        }
        public DataResult<int> TestE7()
        {
            return this.DataResult(100); 
        }
        public DataResult<int> TestE8()
        {
            return this.DataResult(100, ResultTypes.Success);
        }

        public DataResult<int, ResultTypes> TestF1()
        {
            return this.Success(100);
        }
        public DataResult<int, ResultTypes> TestF2()
        {
            return 100;
        }
        public DataResult<int, ResultTypes> TestF3()
        {
            return this.Failure();
        }
        public DataResult<int, ResultTypes> TestF4()
        {
            return this.Failure("test1");
        }
        public DataResult<int, ResultTypes> TestF5()
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

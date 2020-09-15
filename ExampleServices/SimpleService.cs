using System;
using System.IO;
using ServiceLayer;

namespace ExampleServices
{
    public class SimpleService : IService
    {
        public Result DoOperation()
        {
            try
            {
                // Some sort of operation here
                return this.Success();
            }
            catch
            {
                return this.Failure();
            }
        }

        public Result DoOperationWithErrorMessage()
        {
            try
            {
                // Some sort of operation here
                return this.Success();
            }
            catch(Exception ex)
            {
                return this.Failure(ex.Message);
            }
        }

        public Result DoOperationWithMultipleErrors()
        {
            try
            {
                // Some sort of operation here
                return this.Success();
            }
            catch (Exception ex)
            {
                return this.Failure(ex.Message, "error 2", 3, false);
            }
        }

        public Result<ResultType, int> DoOperationWithErrorCode()
        {
            try
            {
                // Some sort of operation here
                return this.Success();
            }
            catch (IOException ioex)
            {
                return 1000;
            }
            catch (TimeoutException tex)
            {
                return 2000;
            }
            catch (Exception ex)
            {
                return 5000;
            }
        }


        public DataResult<string, ResultType, int> GetDataWithErrorCode()
        {
            try
            {
                // Some sort of operation here
                return "test data";
            }
            catch (IOException ioex)
            {
                return 1000;
            }
            catch (TimeoutException tex)
            {
                return 2000;
            }
            catch (Exception ex)
            {
                return 5000;
            }
        }
    }
}

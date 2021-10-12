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

        public Result<ResultType, int> DoOperationWithErrorCode()
        {
            try
            {
                // Some sort of operation here
                return this.Success();
            }
            catch (IOException)
            {
                return 1000;
            }
            catch (TimeoutException)
            {
                return 2000;
            }
            catch (Exception)
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
            catch (IOException)
            {
                return 1000;
            }
            catch (TimeoutException)
            {
                return 2000;
            }
            catch (Exception)
            {
                return 5000;
            }
        }
    }
}

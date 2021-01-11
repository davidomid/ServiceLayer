using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ServiceLayer;

namespace ExampleServices
{
    public interface IFileStorageService : IService
    {
        DataResult<TData, FileStorageResultTypes, string> GetData<TData>(string filePath); 
    }
    public class FileStorageService : IFileStorageService
    {


        public DataResult<TData, FileStorageResultTypes, string> GetData<TData>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return this.Result(FileStorageResultTypes.FilePathNotExists, "The specified file path does not exist.");
                }

                string json = File.ReadAllText(filePath);
                TData data = JsonConvert.DeserializeObject<TData>(json);
                return data;
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
    }
}

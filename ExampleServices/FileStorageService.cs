using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ServiceLayer;

namespace ExampleServices
{
    public interface IFileStorageService<T> 
    {
    }

    public class FileStorageService<T> : IService
    {
        private readonly string _filePath;

        public FileStorageService(string filePath)
        {
            _filePath = filePath;
        }

        public DataResult<T, FileStorageResultTypes, string> Get()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    T entity = JsonConvert.DeserializeObject<T>(json);
                    return entity;
                }

                return this.Result(FileStorageResultTypes.FilePathNotExists, "The specified file path does not exist.");
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
    }
}

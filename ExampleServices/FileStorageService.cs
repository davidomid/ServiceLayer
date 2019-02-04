using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ServiceLayer;

namespace ExampleServices
{
    public class FileStorageService<TEntity> : IStorageService<TEntity> where TEntity : Entity
    {
        private readonly string _filePath;

        public FileStorageService(string filePath)
        {
            _filePath = filePath;
        }

        public DataServiceResult<List<TEntity>, FileStorageServiceResultTypes> Get()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    List<TEntity> entities = JsonConvert.DeserializeObject<List<TEntity>>(json);
                    return entities;
                }

                return FileStorageServiceResultTypes.FilePathNotExists;
            }
            catch (Exception ex)
            {
                return this.Failure(ex.Message); 
            }
        }

        public ServiceResult Add(TEntity entity)
        {
            try
            {
                var allEntitiesResult = this.Get();
                if (allEntitiesResult.IsSuccessful)
                {
                    List<TEntity> entities = allEntitiesResult.Data?.ToList() ?? new List<TEntity>();
                    entities.Add(entity);
                    string json = JsonConvert.SerializeObject(entities);
                    File.WriteAllText(_filePath, json);
                }

                return this.Failure(allEntitiesResult.ErrorMessages);
            }
            catch (Exception ex)
            {
                return this.Failure(ex.Message);
            }
        }

        public DataServiceResult<TEntity> GetByKey(string key)
        {
            var allEntitiesResult = this.Get();
            if (allEntitiesResult.IsSuccessful)
            {
                return allEntitiesResult.Data?.FirstOrDefault(d => d.Key == key); 
            }

            return this.Failure(allEntitiesResult.ErrorMessages);
        }

        IDataServiceResult<IEnumerable<TEntity>> IStorageService<TEntity>.Get()
        {
            return this.Get(); 
        }

        IServiceResult IStorageService<TEntity>.Add(TEntity entity)
        {
            return this.Add(entity); 
        }

        IDataServiceResult<TEntity> IStorageService<TEntity>.GetByKey(string key)
        {
            return this.GetByKey(key);
        }
    }
}

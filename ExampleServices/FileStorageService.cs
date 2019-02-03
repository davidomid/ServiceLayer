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

        public IDataServiceResult<IEnumerable<TEntity>> Get()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    IEnumerable<TEntity> entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
                    return entities;
                }
                return this.Failure($"The file path \"{_filePath}\" does not exist.");
            }
            catch (Exception ex)
            {
                return this.Failure(ex.Message); 
            }
        }

        public IServiceResult Add(TEntity entity)
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

        public IDataServiceResult<TEntity> GetByKey(string key)
        {
            var allEntitiesResult = this.Get();
            if (allEntitiesResult.IsSuccessful)
            {
                return allEntitiesResult.Data?.FirstOrDefault(); 
            }

            return this.Failure(allEntitiesResult.ErrorMessages);
        }
    }
}

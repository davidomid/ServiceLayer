using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                IEnumerable<TEntity> entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
                return entities;
            }
            return this.Failure($"The file path \"{_filePath}\" does not exist.");
        }

        public IServiceResult Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IDataServiceResult<TEntity> GetByKey(string key)
        {
            var allEntitiesResult = this.Get();
            if (allEntitiesResult.IsSuccessful)
            {
                return allEntitiesResult.Data.FirstOrDefault(); 
            }

            return this.Failure(allEntitiesResult.ErrorMessages);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace ExampleServices
{
    public class MemoryStorageService<TEntity> : IStorageService<TEntity> where TEntity : Entity
    {
        private readonly List<TEntity> _entities = new List<TEntity>();

        public IServiceResult Add(TEntity entity)
        {
            IServiceResult result;
            //if (_entities.Exists(e => e.Key == entity.Key))
            //{
            //    result = this.Failure($"An entity already exists with the key {entity.Key}"); 
            //}
            //else
            //{
            //    _entities.Add(entity);
            //    result = this.Success(); 
            //}

            _entities.Add(entity);
            //return this.Success();
        }

        public IDataServiceResult<IEnumerable<TEntity>> Get()
        {
            return _entities;  
        }

        public IDataServiceResult<TEntity> GetByKey(string key)
        {
            return _entities.FirstOrDefault(e => e.Key == key);
        }
    }
}

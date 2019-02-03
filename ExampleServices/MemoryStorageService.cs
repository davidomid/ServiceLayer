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

        public ServiceResult Add(TEntity entity)
        {
            _entities.Add(entity);
            return this.Success();
        }

        public DataServiceResult<IEnumerable<TEntity>> Get()
        {
            return _entities;  
        }

        public DataServiceResult<TEntity> GetByKey(string key)
        {
            return _entities.FirstOrDefault(e => e.Key == key);
        }

        IServiceResult IStorageService<TEntity>.Add(TEntity entity)
        {
            return this.Add(entity);
        }

        IDataServiceResult<IEnumerable<TEntity>> IStorageService<TEntity>.Get()
        {
            return this.Get();
        }

        IDataServiceResult<TEntity> IStorageService<TEntity>.GetByKey(string key)
        {
            return this.GetByKey(key);
        }
    }
}

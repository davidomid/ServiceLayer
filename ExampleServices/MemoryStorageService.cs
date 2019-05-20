using System.Collections.Generic;
using System.Linq;
using ServiceLayer;

namespace ExampleServices
{
    public class MemoryStorageService<TEntity> : IStorageService<TEntity> where TEntity : Entity
    {
        private readonly List<TEntity> _entities = new List<TEntity>();

        public IServiceResult Add(TEntity entity)
        {
            _entities.Add(entity);
            return this.Success();
        }

        public IDataServiceResult<IEnumerable<TEntity>> Get()
        {
            return this.Success(_entities); 
        }

        public IDataServiceResult<TEntity> GetByKey(string key)
        {
            return this.Success(_entities.FirstOrDefault(e => e.Key == key));
        }
    }
}

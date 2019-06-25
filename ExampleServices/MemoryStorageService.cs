using System.Collections.Generic;
using System.Linq;
using ServiceLayer;

namespace ExampleServices
{
    public class MemoryStorageService<TEntity> : IStorageService<TEntity> where TEntity : Entity
    {
        private readonly List<TEntity> _entities = new List<TEntity>();

        public IResult Add(TEntity entity)
        {
            _entities.Add(entity);
            return this.Success();
        }

        public IDataResult<IEnumerable<TEntity>> Get()
        {
            return this.Success(_entities); 
        }

        public IDataResult<TEntity> GetByKey(string key)
        {
            return this.Success(_entities.FirstOrDefault(e => e.Key == key));
        }
    }
}

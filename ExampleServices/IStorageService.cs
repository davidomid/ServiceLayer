using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceLayer;

namespace ExampleServices
{
    public interface IStorageService<TEntity> : IService where TEntity : Entity
    {
        IDataServiceResult<IEnumerable<TEntity>> Get();

        IServiceResult Add(TEntity entity);

        IDataServiceResult<TEntity> GetByKey(string key); 
    }
}

using System.Collections.Generic;
using ServiceLayer;

namespace ExampleServices
{
    public interface IStorageService<TEntity> : IService where TEntity : Entity
    {
        IDataResult<IEnumerable<TEntity>> Get();

        IResult Add(TEntity entity);

        IDataResult<TEntity> GetByKey(string key); 
    }
}

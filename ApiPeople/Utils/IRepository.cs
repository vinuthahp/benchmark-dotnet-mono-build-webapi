using System.Collections.Generic;

namespace ApiPeople.Utils
{
    public interface IRepository<TEntity, TId>
    {
		IEnumerable<TEntity> Query(IDictionary<string, object> queryData);

        TEntity New();

        TEntity Get(TId id);

        bool Remove(TId id);

        void CommitChanges();
    }
}

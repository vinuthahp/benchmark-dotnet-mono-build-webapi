using System.Collections.Generic;
using System.Collections.Specialized;

namespace ApiPeople.Utils
{
    public interface IRepository<TEntity, TId>
    {
		IEnumerable<TEntity> Query(NameValueCollection queryData);

        TEntity New();

        TEntity Get(TId id);

        bool Remove(TId id);

        void CommitChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using ApiPeople.Utils;

namespace ApiPeople.Infra.EF6
{
    public abstract class EF6RepositoryBase<TQueryForm, TEntity, TId> : IRepository<TQueryForm, TEntity, TId>
    {
        private readonly IDbContext context;

        public EF6RepositoryBase(IDbContext context)
        {
            this.context = context;
        }

        protected IDbContext Context
        {
            get
            {
                return context;
            }
        }

		public abstract IEnumerable<TEntity> Query(TQueryForm queryData);

        public abstract TEntity New();

        public abstract TEntity Get(TId id);

        public abstract bool Remove(TId id);

        public void CommitChanges()
        {
			Context.SaveChanges();
        }
	}
}

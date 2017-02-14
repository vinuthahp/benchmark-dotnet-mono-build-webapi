using System;
using System.Collections.Generic;
using System.Linq;
using ApiPeople.Domain.Person;

namespace ApiPeople.Infra.EF6
{
	public class EF6PersonRepository : EF6RepositoryBase<PersonEntity, int>, IPersonRepository
	{
		public EF6PersonRepository(IDbContext context) : base(context) { }

		public override IEnumerable<PersonEntity> Query(IDictionary<string, object> queryData)
		{
			var query = Context.People.AsQueryable();

			if (queryData.ContainsKey("name"))
				query = query.Where(d => d.Name.Contains((string)queryData["name"]));

			if (queryData.ContainsKey("dobFrom"))
				query = query.Where(d => d.DOB >= (DateTime)queryData["dobFrom"]);

			if (queryData.ContainsKey("dobUntil"))
				query = query.Where(d => d.DOB >= (DateTime)queryData["dobUntil"]);

			return query.ToArray();
		}

		public override PersonEntity New()
		{
			var entity = Context.People.Create();
			Context.People.Add(entity);
			return entity;
		}

		public override PersonEntity Get(int id)
		{
			return Context.People
				.Where(d => d.Id == id)
				.FirstOrDefault();
		}

		public override bool Remove(int id)
		{
			var entity = Get(id);
			if (entity != null)
			{
				Context.People.Remove(entity);
				return true;
			}

			return false;
		}
	}
}

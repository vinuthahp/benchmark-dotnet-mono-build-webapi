using ApiPeople.Domain.Person;
using System.Collections.Generic;
using System.Linq;

namespace ApiPeople.Infra.EF6
{
    public class EF6PersonRepository : EF6RepositoryBase<PersonQueryForm, PersonEntity, int>, IPersonRepository
	{
		public EF6PersonRepository(IDbContext context) : base(context) { }

		public override IEnumerable<PersonEntity> Query(PersonQueryForm queryData)
		{
			var query = Context.People.AsQueryable();

			if (queryData.Name != null)
				query = query.Where(d => d.Name.Contains(queryData.Name));

            if (queryData.DOBFrom.HasValue)
                query = query.Where(d => d.DOB >= queryData.DOBFrom);

			if (queryData.DOBUntil.HasValue)
				query = query.Where(d => d.DOB <= queryData.DOBUntil);

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

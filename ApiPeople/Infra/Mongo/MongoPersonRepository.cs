using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ApiPeople.Domain.Person;

namespace ApiPeople
{
	public class MongoPersonRepository : IPersonRepository
	{
		public PersonEntity Get(int id)
		{
			throw new NotImplementedException();
		}

		public PersonEntity New()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PersonEntity> Query(PersonQueryForm queryData)
		{
			throw new NotImplementedException();
		}

		public bool Remove(int id)
		{
			throw new NotImplementedException();
		}

		public void CommitChanges()
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Collections.Generic;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repo;

        public PersonService(IPersonRepository repo)
        {
            this.repo = repo;
        }

        public bool Exists(int id)
        {
            return repo.Get(id) != null;
        }

        public PersonEntity Read(int id)
        {
            return repo.Get(id);
        }

        public WrapperDTO<PersonEntity> List(IDictionary<string, object> queryData)
        {
			return new WrapperDTO<PersonEntity>(repo.Query(queryData));
        }

        public PersonEntity Create(IDictionary<string, object> formData)
        {
            var person = repo.New();
            person.CopyFrom(formData);
            repo.CommitChanges();
            return person;
        }

        public bool Update(int id, IDictionary<string, object> formData)
        {
            var person = repo.Get(id);
            if (person == null)
                return false;

			person.CopyFrom(formData);
            repo.CommitChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var result = repo.Remove(id);
            repo.CommitChanges();
			return result;
        }
    }
}

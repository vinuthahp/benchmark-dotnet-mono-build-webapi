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

        public IEnumerable<PersonEntity> List(IDictionary<string, object> queryData)
        {
            return repo.Query(queryData);
        }

        public PersonEntity Create(IDictionary<string, object> formData)
        {
            var person = repo.New();
            updateEntity(formData, person);
            repo.CommitChanges();
            return person;
        }

        public bool Update(int id, IDictionary<string, object> formData)
        {
            var person = repo.Get(id);
            if (person == null)
                return false;

            updateEntity(formData, person);
            repo.CommitChanges();
            return true;
        }

        private void updateEntity(IDictionary<string, object> formData, PersonEntity entity)
        {
            if (formData.ContainsKey("name"))
                entity.Name = (string) formData["name"];

            if (formData.ContainsKey("dob"))
                entity.DOB = (DateTime) formData["dob"];
        }

        public bool Delete(int id)
        {
            var result = repo.Remove(id);
            repo.CommitChanges();
			return result;
        }
    }
}

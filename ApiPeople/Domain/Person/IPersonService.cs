using System.Collections.Generic;

namespace ApiPeople.Domain.Person
{
    public interface IPersonService
    {
        bool Exists(int id);

        PersonEntity Read(int id);

        IEnumerable<PersonEntity> List(IDictionary<string, object> queryData);

        PersonEntity Create(IDictionary<string, object> formData);

        bool Update(int id, IDictionary<string, object> formData);

        bool Delete(int id);
    }
}

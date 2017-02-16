using System.Collections.Generic;
using System.Collections.Specialized;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
    public interface IPersonService
    {
        bool Exists(int id);

        PersonEntity Read(int id);

        WrapperDTO<PersonEntity> List(PersonQueryForm queryData);

        PersonEntity Create(PersonInputForm formData);

        bool Update(int id, PersonInputForm formData);

        bool Delete(int id);
    }
}

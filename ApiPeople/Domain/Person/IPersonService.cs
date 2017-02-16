using System.Collections.Generic;
using System.Collections.Specialized;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
    public interface IPersonService
    {
        bool Exists(int id);

        PersonEntity Read(int id);

        WrapperDTO<PersonEntity> List(NameValueCollection queryData);

        PersonEntity Create(NameValueCollection formData);

        bool Update(int id, NameValueCollection formData);

        bool Delete(int id);
    }
}
